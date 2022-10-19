using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace NidaTech.DadosPublicos.Localization
{
    public static class DadosPublicosLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(DadosPublicosConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(DadosPublicosLocalizationConfigurer).GetAssembly(),
                        "NidaTech.DadosPublicos.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
