using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NidaTech.DadosPublicos.Services.Dto;
using System.Threading.Tasks;

namespace NidaTech.DadosPublicos.Services
{
    public interface IDadoCadastralAppService :
        IAsyncCrudAppService<
            DadoCadastral,
            int,
            PagedAndSortedResultRequestDto,
            DadoCadastralCriar,
            DadoCadastralAtualizar>
    {
        Task<DadoCadastral> GetByCnpjAsync(string cnpj);
        //Task<SeekResultDto<DadoCadastralDto>> GetByRazaoSocialNomeEmpresarialAsync(SeekRequestDto input);
    }
}
