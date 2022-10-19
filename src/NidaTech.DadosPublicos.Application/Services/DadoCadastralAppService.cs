using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using NidaTech.DadosPublicos.Modelos;
using NidaTech.DadosPublicos.Services.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace NidaTech.DadosPublicos.Services
{
    //[AbpAuthorize]
    public class DadoCadastralAppService :
        DadosPublicosCrudAppServiceBase<
            DadoCadastralModelo,
            DadoCadastral,
            int,
            PagedAndSortedResultRequestDto,
            DadoCadastralCriar,
            DadoCadastralAtualizar>,
        IDadoCadastralAppService
    {
        public DadoCadastralAppService(IRepository<DadoCadastralModelo, int> repository)
            : base(repository)
        {

        }

        public virtual async Task<DadoCadastral> GetByCnpjAsync(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                throw new UserFriendlyException("É necessário informar o CNPJ para pesquisar");
            var cnpjPesquisar = SomenteNumeros(cnpj);
            if (string.IsNullOrWhiteSpace(cnpjPesquisar))
                throw new UserFriendlyException("É necessário informar o CNPJ para pesquisar");
            if (cnpjPesquisar.Length < 14)
                cnpjPesquisar = string.Concat(new string('0', 14 - cnpjPesquisar.Length), cnpjPesquisar);
            var dadoCadastral = await Repository.FirstOrDefaultAsync(f => f.Cnpj == cnpjPesquisar);
            return ObjectMapper.Map<DadoCadastral>(dadoCadastral);
        }

        //public virtual async Task<SeekResultDto<DadoCadastralDto>> GetByRazaoSocialNomeEmpresarialAsync(SeekRequestDto input)
        //{
        //    if (input.MaxResultCount < 1)
        //        input.MaxResultCount = 1;

        //    if (input.MaxResultCount > 100)
        //        input.MaxResultCount = 100;

        //    if (string.IsNullOrWhiteSpace(input.Direction))
        //        input.Direction = AscendingDirection;
        //    else
        //        input.Direction = input.Direction.Trim().ToUpper();

        //    var query = base.Repository.GetAll();

        //    string ordering = $"RazaoSocialNomeEmpresarial {input.Direction}, Id {input.Direction}";

        //    query = query.OrderBy(ordering);

        //    var sortFields = ordering.Replace($" {input.Direction}", string.Empty).Split(",");

        //    if (!string.IsNullOrWhiteSpace(input.ReferenceValues))
        //    {
        //        var values = input.ReferenceValues.Split("|");
        //        if (values.Length == 1 && !sortFields[0].Equals(nameof(DadoCadastral.Id)))
        //        {
        //            var valuesWithId = values.ToList();
        //            valuesWithId.Add("0");
        //            values = valuesWithId.ToArray();
        //        }
        //        var predicate = $"RazaoSocialNomeEmpresarial >= \"{values[0]}%\" && Id > {values[1]}";
        //        query = query.Where(predicate);
        //    }

        //    query = query.Take(input.MaxResultCount + 1);

        //    var pagedList = await query.ToListAsync();
        //    var resultList = pagedList.Take(input.MaxResultCount).ToList();
        //    bool hasNext;
        //    bool hasPrevious;
        //    if (input.Direction == AscendingDirection)
        //    {
        //        hasNext = pagedList.Count() > input.MaxResultCount;
        //        hasPrevious = !string.IsNullOrWhiteSpace(input.ReferenceValues);
        //    }
        //    else
        //    {
        //        resultList.Reverse();
        //        hasNext = !string.IsNullOrWhiteSpace(input.ReferenceValues);
        //        hasPrevious = pagedList.Count() > input.MaxResultCount;
        //    }
        //    var firstItem = resultList.FirstOrDefault();
        //    var lastItem = resultList.LastOrDefault();

        //    var seekPagedResultDto = new SeekResultDto<DadoCadastralDto>
        //    {
        //        Items = ObjectMapper.Map<IReadOnlyList<DadoCadastralDto>>(resultList),
        //        TotalCount = resultList.Count(),
        //        HasNext = hasNext,
        //        HasPrevious = hasPrevious,
        //        FirstValues = GetValuesFromObject(ObjectMapper.Map<DadoCadastralDto>(firstItem), sortFields),
        //        LastValues = GetValuesFromObject(ObjectMapper.Map<DadoCadastralDto>(lastItem), sortFields),
        //        Direction = input.Direction
        //    };

        //    return seekPagedResultDto;
        //}
    }
}
