using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using NidaTech.DadosPublicos.Modelos;
using NidaTech.DadosPublicos.Services.Dto;
using System.Threading.Tasks;

namespace NidaTech.DadosPublicos.Services
{
    [AbpAuthorize]
    public class MunicipioAppService :
        DadosPublicosCrudAppServiceBase<
            MunicipioModelo,
            Municipio,
            int,
            PagedAndSortedResultRequestDto,
            MunicipioCriar,
            MunicipioAtualizar>,
        IMunicipioAppService
    {
        public MunicipioAppService(IRepository<MunicipioModelo, int> repository)
            : base(repository)
        {

        }

        [AbpAllowAnonymous]
        public override Task<PagedResultDto<Municipio>> GetAllAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        [AbpAllowAnonymous]
        public override Task<Municipio> GetAsync(EntityDto<int> input)
        {
            return base.GetAsync(input);
        }
    }
}