using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class AtividadeEconomicaAtualizar : AtividadeEconomicaCriar, IEntityDto<int>
    {
        [Required]
        public int Id { get; set; }
    }
}
