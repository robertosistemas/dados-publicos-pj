using Abp.Application.Services.Dto;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class UnidadeFederacaoRequest : PagedAndSortedResultRequestDto
    {
        public virtual bool Mostrar { get; set; }
    }
}
