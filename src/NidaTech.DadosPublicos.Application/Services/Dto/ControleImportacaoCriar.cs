using System;
using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class ControleImportacaoCriar
    {
        [Required]
        [StringLength(11)]
        public string NomeArquivo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataGravacao { get; set; }

        [Required]
        [StringLength(8)]
        public string NumeroRemessa { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataImportacao { get; set; }
    }
}
