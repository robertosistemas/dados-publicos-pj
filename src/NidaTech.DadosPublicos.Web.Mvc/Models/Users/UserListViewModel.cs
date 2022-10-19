using System.Collections.Generic;
using NidaTech.DadosPublicos.Roles.Dto;

namespace NidaTech.DadosPublicos.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
