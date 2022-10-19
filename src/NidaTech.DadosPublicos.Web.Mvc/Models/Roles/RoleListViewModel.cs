using System.Collections.Generic;
using NidaTech.DadosPublicos.Roles.Dto;

namespace NidaTech.DadosPublicos.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
