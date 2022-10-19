using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using NidaTech.DadosPublicos.Controllers;

namespace NidaTech.DadosPublicos.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : DadosPublicosControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PesquisarEmpresas(string PesquisaEmpresasInput)
        {
            try
            {
                ViewBag.ValorPadrao = PesquisaEmpresasInput;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
