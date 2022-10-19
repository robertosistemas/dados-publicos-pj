using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class MotivoSituacaoCadastralAtualizar : EntityDto<int>
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }
    }
}
