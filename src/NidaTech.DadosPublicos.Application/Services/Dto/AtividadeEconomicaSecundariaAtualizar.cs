using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class AtividadeEconomicaSecundariaAtualizar : EntityDto<int>
    {
        [Required]
        [StringLength(14)]
        public string Cnpj { get; set; }

        [Required]
        public int AtividadeEconomicaId { get; set; }
    }
}
