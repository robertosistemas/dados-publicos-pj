using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using NidaTech.DadosPublicos.Authorization.Users;
using NidaTech.DadosPublicos.Editions;

namespace NidaTech.DadosPublicos.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
