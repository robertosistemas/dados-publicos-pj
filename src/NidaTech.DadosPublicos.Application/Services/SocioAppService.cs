using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using NidaTech.DadosPublicos.Modelos;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos.Services
{
    [AbpAuthorize]
    public class SocioAppService :
        DadosPublicosCrudAppServiceBase<
            SocioModelo,
            Socio,
            int,
            PagedAndSortedResultRequestDto,
            SocioCriar,
            SocioAtualizar>,
        ISocioAppService
    {
        public SocioAppService(IRepository<SocioModelo, int> repository)
            : base(repository)
        {

        }
    }
}