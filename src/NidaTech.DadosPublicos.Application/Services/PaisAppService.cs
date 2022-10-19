using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using NidaTech.DadosPublicos.Modelos;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos.Services
{
    [AbpAuthorize]
    public class PaisAppService :
        DadosPublicosCrudAppServiceBase<
            PaisModelo,
            Pais,
            int,
            PagedAndSortedResultRequestDto,
            PaisCriar,
            PaisAtualizar>,
        IPaisAppService
    {
        public PaisAppService(IRepository<PaisModelo, int> repository)
            : base(repository)
        {

        }
    }
}