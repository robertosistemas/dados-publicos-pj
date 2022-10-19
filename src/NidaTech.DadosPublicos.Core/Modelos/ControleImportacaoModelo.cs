using System;
using Abp.Domain.Entities;

namespace NidaTech.DadosPublicos.Modelos
{
    public class ControleImportacaoModelo : Entity<int>
    {
        public string NomeArquivo { get; set; }
        public DateTime DataGravacao { get; set; }
        public string NumeroRemessa { get; set; }
        public DateTime? DataImportacao { get; set; }
    }
}
