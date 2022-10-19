using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class MotivoSituacaoCadastralCriar
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }
    }
}
