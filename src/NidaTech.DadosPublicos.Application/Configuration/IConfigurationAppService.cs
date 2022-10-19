using System.Threading.Tasks;
using NidaTech.DadosPublicos.Configuration.Dto;

namespace NidaTech.DadosPublicos.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
