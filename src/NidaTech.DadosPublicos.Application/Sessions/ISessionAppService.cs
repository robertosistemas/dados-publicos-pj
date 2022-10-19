using System.Threading.Tasks;
using Abp.Application.Services;
using NidaTech.DadosPublicos.Sessions.Dto;

namespace NidaTech.DadosPublicos.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
