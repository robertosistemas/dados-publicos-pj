using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace NidaTech.DadosPublicos.Controllers
{
    public abstract class DadosPublicosControllerBase: AbpController
    {
        protected DadosPublicosControllerBase()
        {
            LocalizationSourceName = DadosPublicosConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
