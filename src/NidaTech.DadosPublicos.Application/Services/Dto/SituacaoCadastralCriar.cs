using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class SituacaoCadastralCriar
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [StringLength(8)]
        public string Descricao { get; set; }
    }
}
