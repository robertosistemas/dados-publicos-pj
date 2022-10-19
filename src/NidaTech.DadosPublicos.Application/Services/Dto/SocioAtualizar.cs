using Abp.Application.Services.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class SocioAtualizar : EntityDto<int>
    {
        [Required]
        [StringLength(14)]
        public string Cnpj { get; set; }

        [Required]
        public int TipoSocioId { get; set; }

        [Required]
        [StringLength(150)]
        public string Nome { get; set; }

        [StringLength(14)]
        public string CpfCnpj { get; set; }

        public int? QualificacaoSocioId { get; set; }

        public decimal? PercentualCapitalSocial { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataEntradaSociedade { get; set; }

        public int? PaisId { get; set; }

        [StringLength(11)]
        public string CpfRepresentanteLegal { get; set; }

        [StringLength(60)]
        public string NomeRepresentanteLegal { get; set; }

        public int? QualificacaoRepresentanteId { get; set; }
    }
}
