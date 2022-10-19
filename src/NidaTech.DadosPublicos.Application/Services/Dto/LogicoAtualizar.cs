using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class LogicoAtualizar : EntityDto<int>
    {
        [Required]
        [StringLength(1)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(5)]
        public string Descricao { get; set; }
    }
}
