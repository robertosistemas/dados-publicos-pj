using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class MatrizFilialCriar
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [StringLength(8)]
        public string Descricao { get; set; }
    }
}
