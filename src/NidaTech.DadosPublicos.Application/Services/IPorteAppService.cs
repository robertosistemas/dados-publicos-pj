using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos.Services
{
    public interface IPorteAppService :
        IAsyncCrudAppService<
            Porte,
            int,
            PagedAndSortedResultRequestDto,
            PorteCriar,
            PorteAtualizar>
    {

    }
}
