using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace NidaTech.DadosPublicos.Web.Views
{
    public abstract class DadosPublicosRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected DadosPublicosRazorPage()
        {
            LocalizationSourceName = DadosPublicosConsts.LocalizationSourceName;
        }
    }
}
