using Abp.Application.Services.Dto;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class Municipio : EntityDto<int>
    {
        public string Codigo { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }
        public int? UnidadeFederacaoId { get; set; }
        public int QuantidadeEmpresasAtivas { get; set; }
        public int QuantidadeEmpresasInativas { get; set; }
    }
}
