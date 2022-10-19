using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NidaTech.DadosPublicos.EntityFrameworkCore;
using NidaTech.DadosPublicos.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace NidaTech.DadosPublicos.Web.Tests
{
    [DependsOn(
        typeof(DadosPublicosWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class DadosPublicosWebTestModule : AbpModule
    {
        public DadosPublicosWebTestModule(DadosPublicosEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DadosPublicosWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(DadosPublicosWebMvcModule).Assembly);
        }
    }
}