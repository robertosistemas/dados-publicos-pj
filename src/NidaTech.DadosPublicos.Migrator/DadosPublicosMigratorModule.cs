using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NidaTech.DadosPublicos.Configuration;
using NidaTech.DadosPublicos.EntityFrameworkCore;
using NidaTech.DadosPublicos.Migrator.DependencyInjection;

namespace NidaTech.DadosPublicos.Migrator
{
    [DependsOn(typeof(DadosPublicosEntityFrameworkModule))]
    public class DadosPublicosMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public DadosPublicosMigratorModule(DadosPublicosEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(DadosPublicosMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                DadosPublicosConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DadosPublicosMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
