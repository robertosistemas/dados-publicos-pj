using Abp.AutoMapper;
using NidaTech.DadosPublicos.Sessions.Dto;

namespace NidaTech.DadosPublicos.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
