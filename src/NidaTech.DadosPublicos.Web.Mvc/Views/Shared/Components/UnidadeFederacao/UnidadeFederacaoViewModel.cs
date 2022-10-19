using NidaTech.DadosPublicos.Services.Dto;
using System.Collections.Generic;

namespace NidaTech.DadosPublicos.Web.Views.Shared.Components.UnidadeFederacao
{
    public class UnidadeFederacaoViewModel
    {
        public IReadOnlyList<Services.Dto.UnidadeFederacao> UnidadesFederacao { get; set; }
    }
}
