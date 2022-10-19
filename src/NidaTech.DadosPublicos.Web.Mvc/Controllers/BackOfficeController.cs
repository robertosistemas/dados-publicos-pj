using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using NidaTech.DadosPublicos.Controllers;

namespace NidaTech.DadosPublicos.Web.Controllers
{
    [AbpMvcAuthorize]
    public class BackOfficeController : DadosPublicosControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
