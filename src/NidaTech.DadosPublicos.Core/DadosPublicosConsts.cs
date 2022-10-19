using NidaTech.DadosPublicos.Debugging;

namespace NidaTech.DadosPublicos
{
    public class DadosPublicosConsts
    {
        public const string LocalizationSourceName = "DadosPublicos";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "9902e8d8c792433f94c864dc903e3496";
    }
}
