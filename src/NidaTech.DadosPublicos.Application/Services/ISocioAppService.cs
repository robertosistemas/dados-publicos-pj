using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos.Services
{
    public interface ISocioAppService :
        IAsyncCrudAppService<
            Socio,
            int,
            PagedAndSortedResultRequestDto,
            SocioCriar,
            SocioAtualizar>
    {

    }
}
