using Abp.Application.Services;
using NidaTech.DadosPublicos.MultiTenancy.Dto;

namespace NidaTech.DadosPublicos.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

