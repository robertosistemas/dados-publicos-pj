using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos.Services
{
    public interface ISituacaoCadastralAppService :
        IAsyncCrudAppService<
            SituacaoCadastral,
            int,
            PagedAndSortedResultRequestDto,
            SituacaoCadastralCriar,
            SituacaoCadastralAtualizar>
    {

    }
}
