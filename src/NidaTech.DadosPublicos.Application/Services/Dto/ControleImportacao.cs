using System;
using Abp.Application.Services.Dto;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class ControleImportacao : EntityDto<int>
    {
        public string NomeArquivo { get; set; }
        public DateTime DataGravacao { get; set; }
        public string NumeroRemessa { get; set; }
        public DateTime? DataImportacao { get; set; }
    }
}
