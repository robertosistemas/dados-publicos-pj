using Abp.AutoMapper;
using NidaTech.DadosPublicos.Roles.Dto;
using NidaTech.DadosPublicos.Web.Models.Common;

namespace NidaTech.DadosPublicos.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
