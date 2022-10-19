using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class QualificacaoCriar
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
