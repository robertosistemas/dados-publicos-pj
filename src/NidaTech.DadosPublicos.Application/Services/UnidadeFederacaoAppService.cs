using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using NidaTech.DadosPublicos.Modelos;
using NidaTech.DadosPublicos.Services.Dto;
using System.Linq;
using System.Threading.Tasks;

namespace NidaTech.DadosPublicos.Services
{
    [AbpAuthorize]
    public class UnidadeFederacaoAppService :
        DadosPublicosCrudAppServiceBase<
            UnidadeFederacaoModelo,
            UnidadeFederacao,
            int,
            UnidadeFederacaoRequest,
            UnidadeFederacaoCriar,
            UnidadeFederacaoAtualizar>,
        IUnidadeFederacaoAppService
    {
        public UnidadeFederacaoAppService(IRepository<UnidadeFederacaoModelo, int> repository)
            : base(repository)
        {

        }

        [AbpAllowAnonymous]
        public override async Task<PagedResultDto<UnidadeFederacao>> GetAllAsync(UnidadeFederacaoRequest input)
        {
            var result = await base.GetAllAsync(input);
            if (result != null)
            {
                result.Items = result.Items.Where(f => f.Mostrar == input.Mostrar).ToList();
            }
            return result;
        }

        [AbpAllowAnonymous]
        public override async Task<UnidadeFederacao> GetAsync(EntityDto<int> input)
        {
            return await base.GetAsync(input);
        }
    }
}
