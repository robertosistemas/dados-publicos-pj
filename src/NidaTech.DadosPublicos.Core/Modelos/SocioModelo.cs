using System;
using Abp.Domain.Entities;

namespace NidaTech.DadosPublicos.Modelos
{
    public class SocioModelo : Entity<int>
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
