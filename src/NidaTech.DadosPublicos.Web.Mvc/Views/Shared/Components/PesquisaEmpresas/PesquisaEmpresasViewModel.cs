using NidaTech.DadosPublicos.Services.Dto;
using System.Collections.Generic;

namespace NidaTech.DadosPublicos.Web.Views.Shared.Components.PesquisaEmpresas
{
    public class PesquisaEmpresasViewModel
    {
        public IReadOnlyList<Services.Dto.UnidadeFederacao> UnidadesFederacao { get; set; }
    }
}
