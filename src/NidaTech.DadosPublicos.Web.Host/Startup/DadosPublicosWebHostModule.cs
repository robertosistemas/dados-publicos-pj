using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NidaTech.DadosPublicos.Configuration;

namespace NidaTech.DadosPublicos.Web.Host.Startup
{
    [DependsOn(
       typeof(DadosPublicosWebCoreModule))]
    public class DadosPublicosWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public DadosPublicosWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DadosPublicosWebHostModule).GetAssembly());
        }
    }
}
