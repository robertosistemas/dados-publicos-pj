using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class PorteCriar
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [StringLength(30)]
        public string Descricao { get; set; }
    }
}
