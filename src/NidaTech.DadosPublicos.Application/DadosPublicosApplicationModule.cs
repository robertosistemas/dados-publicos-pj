using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NidaTech.DadosPublicos.Authorization;

namespace NidaTech.DadosPublicos
{
    [DependsOn(
        typeof(DadosPublicosCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class DadosPublicosApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<DadosPublicosAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(DadosPublicosApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
