using System.Collections.Generic;
using NidaTech.DadosPublicos.Roles.Dto;

namespace NidaTech.DadosPublicos.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}