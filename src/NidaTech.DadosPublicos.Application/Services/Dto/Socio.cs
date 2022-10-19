using System;
using Abp.Application.Services.Dto;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class Socio : EntityDto<int>
    {
        public string Cnpj { get; set; }
        public int TipoSocioId { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public int? QualificacaoSocioId { get; set; }
        public decimal? PercentualCapitalSocial { get; set; }
        public DateTime? DataEntradaSociedade { get; set; }
        public int? PaisId { get; set; }
        public string CpfRepresentanteLegal { get; set; }
        public string NomeRepresentanteLegal { get; set; }
        public int? QualificacaoRepresentanteId { get; set; }
    }
}
