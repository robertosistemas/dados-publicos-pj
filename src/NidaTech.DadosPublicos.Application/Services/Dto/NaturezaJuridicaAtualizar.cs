using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class NaturezaJuridicaAtualizar : EntityDto<int>
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }
    }
}
