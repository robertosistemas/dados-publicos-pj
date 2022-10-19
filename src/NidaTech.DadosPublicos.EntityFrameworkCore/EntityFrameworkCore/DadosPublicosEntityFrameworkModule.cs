using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using NidaTech.DadosPublicos.EntityFrameworkCore.Seed;
using System.Text;

namespace NidaTech.DadosPublicos.EntityFrameworkCore
{
    [DependsOn(
        typeof(DadosPublicosCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class DadosPublicosEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<DadosPublicosDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        DadosPublicosDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        DadosPublicosDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DadosPublicosEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
