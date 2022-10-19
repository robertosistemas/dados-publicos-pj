using System.Threading.Tasks;
using Abp.Application.Services;
using NidaTech.DadosPublicos.Authorization.Accounts.Dto;

namespace NidaTech.DadosPublicos.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
