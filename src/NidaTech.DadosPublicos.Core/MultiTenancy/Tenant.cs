using Abp.MultiTenancy;
using NidaTech.DadosPublicos.Authorization.Users;

namespace NidaTech.DadosPublicos.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
