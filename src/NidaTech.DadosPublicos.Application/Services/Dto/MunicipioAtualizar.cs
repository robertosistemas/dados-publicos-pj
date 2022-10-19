using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class MunicipioAtualizar : EntityDto<int>
    {
        [Required]
        [StringLength(4)]
        public string Codigo { get; set; }

        [StringLength(14)]
        public string Cnpj { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(2)]
        public string Uf { get; set; }

        public int? UnidadeFederacaoId { get; set; }

        public int QuantidadeEmpresasAtivas { get; set; }

        public int QuantidadeEmpresasInativas { get; set; }
    }
}
