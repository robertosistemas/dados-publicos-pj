using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using NidaTech.DadosPublicos.Configuration.Dto;

namespace NidaTech.DadosPublicos.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : DadosPublicosAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
