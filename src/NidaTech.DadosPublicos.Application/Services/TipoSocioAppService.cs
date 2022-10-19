using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using NidaTech.DadosPublicos.Modelos;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos.Services
{
    [AbpAuthorize]
    public class TipoSocioAppService :
        DadosPublicosCrudAppServiceBase<
            TipoSocioModelo,
            TipoSocio,
            int,
            PagedAndSortedResultRequestDto,
            TipoSocioCriar,
            TipoSocioAtualizar>,
        ITipoSocioAppService
    {
        public TipoSocioAppService(IRepository<TipoSocioModelo, int> repository)
            : base(repository)
        {

        }
    }
}