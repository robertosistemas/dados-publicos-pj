using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NidaTech.DadosPublicos.Authorization.Users;
using NidaTech.DadosPublicos.MultiTenancy;
using NidaTech.DadosPublicos.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace NidaTech.DadosPublicos
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class DadosPublicosCrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput> :
        AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>>,
        IDadosPublicosCrudAppServiceBase<TEntityDto>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TGetAllInput : IPagedAndSortedResultRequest
        where TUpdateInput : IEntityDto<TPrimaryKey>
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected DadosPublicosCrudAppServiceBase(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
            LocalizationSourceName = DadosPublicosConsts.LocalizationSourceName;
        }

        protected virtual async Task<User> GetCurrentUserAsync()
        {
            var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        public override async Task<PagedResultDto<TEntityDto>> GetAllAsync(TGetAllInput input)
        {
            if (input.MaxResultCount < 1)
                input.MaxResultCount = 1;

            if (input.MaxResultCount > 100)
                input.MaxResultCount = 100;

            var query = base.Repository.GetAll();

            if (string.IsNullOrWhiteSpace(input.Sorting))
                query = query.OrderBy(f => f.Id).Skip(input.SkipCount).Take(input.MaxResultCount + 1);
            else
                query = query.OrderBy(input.Sorting).Skip(input.SkipCount).Take(input.MaxResultCount + 1);

            var resultList = await query.ToListAsync();

            var pagedResultDto = new PagedResultDto<TEntityDto>
            {
                Items = ObjectMapper.Map<IReadOnlyList<TEntityDto>>(resultList.Take(input.MaxResultCount).ToList()),
                TotalCount = resultList.Count() > input.MaxResultCount ? 1 : 0
            };

            return pagedResultDto;
        }

        protected readonly string AscendingDirection = "ASC";
        protected readonly string DescendingDirection = "DESC";

        public virtual async Task<SeekResult<TEntityDto>> GetAllItemsAsync(SeekSortedRequest input)
        {
            if (input.MaxResultCount < 1)
                input.MaxResultCount = 1;

            if (input.MaxResultCount > 100)
                input.MaxResultCount = 100;

            if (string.IsNullOrWhiteSpace(input.Direction))
                input.Direction = AscendingDirection;
            else
                input.Direction = input.Direction.Trim().ToUpper();

            if (string.IsNullOrWhiteSpace(input.Sorting))
                input.Sorting = nameof(Entity.Id);

            var sortFields = input.Sorting.Split('|');

            if (string.Compare(sortFields.Last(), nameof(Entity.Id), true) != 0)
            {
                var sortFieldsWithId = sortFields.ToList();
                sortFieldsWithId.Add(nameof(Entity.Id));
                sortFields = sortFieldsWithId.ToArray();
            }

            var query = base.Repository.GetAll();

            string ordering;
            if (string.Compare(input.Direction, AscendingDirection, true) == 0)
            {
                if (sortFields.Length == 1)
                    ordering = sortFields[0];
                else
                    ordering = string.Join($", ", sortFields);
            }
            else
            {
                if (sortFields.Length == 1)
                    ordering = $"{sortFields[0]} {DescendingDirection}";
                else
                    ordering = string.Concat(string.Join($" {DescendingDirection},", sortFields), " ", DescendingDirection);
            }

            query = query.OrderBy(ordering);

            if (!string.IsNullOrWhiteSpace(input.ReferenceValues))
            {
                var values = input.ReferenceValues.Split('|');
                if (values.Length == 1 && !sortFields[0].Equals(nameof(Entity.Id)))
                {
                    var valuesWithId = values.ToList();
                    valuesWithId.Add("0");
                    values = valuesWithId.ToArray();
                }
                if (values.Length == sortFields.Length)
                {
                    values = GetParameters(sortFields, values).Split('|');
                    var count = 0;
                    var predicate = string.Empty;
                    var relationalOperator = string.Compare(input.Direction, AscendingDirection, true) == 0 ? ">" : "<";
                    foreach (var field in sortFields)
                    {
                        if (count == 0)
                            predicate = $"{field} {relationalOperator} {values[count]}";
                        else
                            predicate = $"{predicate} && {field} {relationalOperator} {values[count]}";
                        count += 1;
                    }
                    query = query.Where(predicate);
                }
            }

            query = query.Take(input.MaxResultCount + 1);

            var pagedList = await query.ToListAsync();
            var resultList = pagedList.Take(input.MaxResultCount).ToList();
            bool hasNext;
            bool hasPrevious;
            if (input.Direction == AscendingDirection)
            {
                hasNext = pagedList.Count() > input.MaxResultCount;
                hasPrevious = !string.IsNullOrWhiteSpace(input.ReferenceValues);
            }
            else
            {
                resultList.Reverse();
                hasNext = !string.IsNullOrWhiteSpace(input.ReferenceValues);
                hasPrevious = pagedList.Count() > input.MaxResultCount;
            }
            var firstItem = resultList.FirstOrDefault();
            var lastItem = resultList.LastOrDefault();

            var seekPagedResultDto = new SeekResult<TEntityDto>
            {
                Items = ObjectMapper.Map<IReadOnlyList<TEntityDto>>(resultList),
                TotalCount = resultList.Count(),
                HasNext = hasNext,
                HasPrevious = hasPrevious,
                FirstValues = GetValuesFromObject(ObjectMapper.Map<TEntityDto>(firstItem), sortFields),
                LastValues = GetValuesFromObject(ObjectMapper.Map<TEntityDto>(lastItem), sortFields),
                Direction = input.Direction
            };

            return seekPagedResultDto;
        }

        protected string GetValuesFromObject(object item, string[] properties)
        {
            var count = 0;
            var values = string.Empty;
            if (item == null)
                return null;
            foreach (var property in properties)
            {
                foreach (var info in item.GetType().GetProperties())
                {
                    if (info.Name.Equals(property))
                    {
                        if (!info.CanRead) continue;

                        var value = info.GetValue(item, null);

                        if (count == 0)
                            values = $"{value}";
                        else
                            values = $"{values}|{value}";

                        count += 1;
                    }
                }
            }
            return values;
        }

        protected string GetParameters(string[] fields, string[] values)
        {
            var count = 0;
            var result = string.Empty;
            foreach (var field in fields)
            {
                var tipo = typeof(TEntity);
                foreach (var info in tipo.GetProperties())
                {
                    if (info.Name.Equals(field))
                    {
                        var value = values[count];
                        var encode = "";

                        if (info.PropertyType.FullName.Equals("System.String"))
                            encode = string.Format("\"{0}\"", value);
                        else if (info.PropertyType.FullName.Equals("System.DateTime"))
                            encode = string.Format("Convert.ToDateTime(\"{0}\")", value);
                        else
                            encode = string.Format("{0}", value);

                        if (count == 0)
                            result = encode;
                        else
                            result = $"{result}|{encode}";

                        count += 1;
                    }
                }
            }
            return result;
        }

        protected string SomenteNumeros(string input)
        {
            const string numbers = "0123456789";
            string output = string.Empty;
            for (var i = 0; i < input.Length; i++)
            {
                if (numbers.IndexOf(input[i]) > -1)
                {
                    output += input[i];
                }
            }
            return output;
        }

    }
}
