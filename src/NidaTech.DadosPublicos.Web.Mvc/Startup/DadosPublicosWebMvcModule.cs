using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NidaTech.DadosPublicos.Configuration;

namespace NidaTech.DadosPublicos.Web.Startup
{
    [DependsOn(typeof(DadosPublicosWebCoreModule))]
    public class DadosPublicosWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public DadosPublicosWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<DadosPublicosNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DadosPublicosWebMvcModule).GetAssembly());
        }
    }
}
