using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class PaisCriar
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
