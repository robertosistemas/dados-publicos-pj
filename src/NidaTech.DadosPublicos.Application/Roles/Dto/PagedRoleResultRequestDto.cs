using Abp.Application.Services.Dto;

namespace NidaTech.DadosPublicos.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

