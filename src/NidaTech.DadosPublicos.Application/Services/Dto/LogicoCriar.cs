using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class LogicoCriar
    {
        [Required]
        [StringLength(1)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(5)]
        public string Descricao { get; set; }
    }
}
