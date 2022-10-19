using Abp.AspNetCore.Mvc.ViewComponents;

namespace NidaTech.DadosPublicos.Web.Views
{
    public abstract class DadosPublicosViewComponent : AbpViewComponent
    {
        protected DadosPublicosViewComponent()
        {
            LocalizationSourceName = DadosPublicosConsts.LocalizationSourceName;
        }
    }
}
