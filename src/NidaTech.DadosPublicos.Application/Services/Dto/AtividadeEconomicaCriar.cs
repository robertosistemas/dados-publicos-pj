using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class AtividadeEconomicaCriar
    {
        [Required]
        [StringLength(1)]
        public string CodigoSecao { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeSecao { get; set; }

        [Required]
        [StringLength(2)]
        public string CodigoDivisao { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeDivisao { get; set; }

        [Required]
        [StringLength(4)]
        public string CodigoGrupo { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeGrupo { get; set; }

        [Required]
        [StringLength(7)]
        public string CodigoClasse { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeClasse { get; set; }

        [Required]
        [StringLength(7)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }

        public int QuantidadeEmpresasAtivas { get; set; }

        public int QuantidadeEmpresasInativas { get; set; }
    }

}
