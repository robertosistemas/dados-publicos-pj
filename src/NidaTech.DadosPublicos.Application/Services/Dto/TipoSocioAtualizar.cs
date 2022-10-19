using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class TipoSocioAtualizar : EntityDto<int>
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [StringLength(30)]
        public string Descricao { get; set; }
    }
}
