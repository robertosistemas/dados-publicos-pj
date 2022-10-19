using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class AtividadeEconomicaSecundariaCriar
    {
        [Required]
        [StringLength(14)]
        public string Cnpj { get; set; }

        [Required]
        public int AtividadeEconomicaId { get; set; }
    }
}
