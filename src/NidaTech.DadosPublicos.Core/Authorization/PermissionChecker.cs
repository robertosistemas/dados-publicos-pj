using Abp.Authorization;
using NidaTech.DadosPublicos.Authorization.Roles;
using NidaTech.DadosPublicos.Authorization.Users;

namespace NidaTech.DadosPublicos.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
