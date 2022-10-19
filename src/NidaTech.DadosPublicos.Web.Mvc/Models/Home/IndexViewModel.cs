using NidaTech.DadosPublicos.Services.Dto;
using System.Collections.Generic;

namespace NidaTech.DadosPublicos.Web.Models.Home
{
    public class IndexViewModel
    {
        public IReadOnlyList<UnidadeFederacao> UnidadesFederacao { get; set; }
    }
}
