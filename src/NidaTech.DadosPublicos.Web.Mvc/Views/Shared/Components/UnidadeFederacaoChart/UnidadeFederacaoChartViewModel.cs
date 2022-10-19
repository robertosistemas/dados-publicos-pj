using NidaTech.DadosPublicos.Services.Dto;
using System.Collections.Generic;

namespace NidaTech.DadosPublicos.Web.Views.Shared.Components.UnidadeFederacaoChart
{
    public class UnidadeFederacaoChartViewModel
    {
        public IReadOnlyList<Services.Dto.UnidadeFederacao> UnidadesFederacao { get; set; }
    }
}
