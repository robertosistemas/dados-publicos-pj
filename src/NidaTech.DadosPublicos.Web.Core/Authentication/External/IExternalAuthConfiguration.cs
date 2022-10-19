using System.Collections.Generic;

namespace NidaTech.DadosPublicos.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
