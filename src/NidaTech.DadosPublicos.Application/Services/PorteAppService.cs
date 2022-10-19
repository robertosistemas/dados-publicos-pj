using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using NidaTech.DadosPublicos.Modelos;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos.Services
{
    [AbpAuthorize]
    public class PorteAppService :
        DadosPublicosCrudAppServiceBase<
            PorteModelo,
            Porte,
            int,
            PagedAndSortedResultRequestDto,
            PorteCriar,
            PorteAtualizar>,
        IPorteAppService
    {
        public PorteAppService(IRepository<PorteModelo, int> repository)
            : base(repository)
        {

        }
    }
}