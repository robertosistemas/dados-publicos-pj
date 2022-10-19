using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class PaisAtualizar : EntityDto<int>
    {
        [Required]
        [StringLength(3)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(70)]
        public string Nome { get; set; }
        public int QuantidadeEmpresasAtivas { get; set; }
        public int QuantidadeEmpresasInativas { get; set; }
    }
}
