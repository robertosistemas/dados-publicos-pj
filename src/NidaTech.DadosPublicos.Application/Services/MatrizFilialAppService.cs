using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using NidaTech.DadosPublicos.Modelos;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos.Services
{
    //[AbpAuthorize]

    public class MatrizFilialAppService :
        DadosPublicosCrudAppServiceBase<
            MatrizFilialModelo,
            MatrizFilial,
            int,
            PagedAndSortedResultRequestDto,
            MatrizFilialCriar,
            MatrizFilialAtualizar>,
        IMatrizFilialAppService
    {
        public MatrizFilialAppService(IRepository<MatrizFilialModelo, int> repository)
            : base(repository)
        {

        }
    }
}