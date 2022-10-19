using System;
using System.ComponentModel.DataAnnotations;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class DadoCadastralCriar
    {
        [Required]
        [StringLength(14)]
        public string Cnpj { get; set; }

        [Required]
        public int MatrizFilialId { get; set; }

        [Required]
        [StringLength(150)]
        public string RazaoSocialNomeEmpresarial { get; set; }

        [StringLength(55)]
        public string NomeFantasia { get; set; }

        public int? SituacaoCadastralId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataSituacaoCadastral { get; set; }

        public int? MotivoSituacaoCadastralId { get; set; }

        [StringLength(55)]
        public string NomeCidadeExterior { get; set; }

        public int? PaisId { get; set; }

        public int? NaturezaJuridicaId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataInicioAtividade { get; set; }

        public int? AtividadeEconomicaId { get; set; }

        [StringLength(20)]
        public string TipoLogradouro { get; set; }

        [StringLength(60)]
        public string Logradouro { get; set; }

        [StringLength(6)]
        public string Numero { get; set; }

        [StringLength(156)]
        public string Complemento { get; set; }

        [StringLength(50)]
        public string Bairro { get; set; }

        [StringLength(8)]
        public string Cep { get; set; }

        public int? UnidadeFederacaoId { get; set; }

        public int? MunicipioId { get; set; }

        [StringLength(4)]
        public string Ddd1 { get; set; }

        [StringLength(9)]
        public string Telefone1 { get; set; }

        [StringLength(4)]
        public string Ddd2 { get; set; }

        [StringLength(9)]
        public string Telefone2 { get; set; }

        [StringLength(4)]
        public string DddFax { get; set; }

        [StringLength(9)]
        public string Fax { get; set; }

        [StringLength(115)]
        public string CorreioEletronico { get; set; }

        public int? QualificacaoResponsavelId { get; set; }

        [DataType(DataType.Currency)]
        public decimal? CapitalSocial { get; set; }

        public int? PorteId { get; set; }

        public int? OpcaoSimplesId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataOpcaoSimples { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataExclusaoSimples { get; set; }

        [StringLength(1)]
        public string OpcaoMei { get; set; }

        [StringLength(23)]
        public string SituacaoEspecial { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataSituacaoEspecial { get; set; }
    }
}
