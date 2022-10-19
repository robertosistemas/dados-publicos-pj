using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class QualificacaoAtualizar : EntityDto<int>
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [StringLength(70)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(1)]
        public string ColetadoAtualmente { get; set; }
    }
}
