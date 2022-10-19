using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class UnidadeFederacaoCriar
    {
        [Required]
        [StringLength(2)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public int? PaisId { get; set; }

        public int QuantidadeEmpresasAtivas { get; set; }

        public int QuantidadeEmpresasInativas { get; set; }
        public bool Mostrar { get; set; } = true;
    }
}
