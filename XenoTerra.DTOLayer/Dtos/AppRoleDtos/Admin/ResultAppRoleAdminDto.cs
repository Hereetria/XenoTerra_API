using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.DTOLayer.Dtos.AppRoleDtos.Admin
{
    public class ResultAppRoleAdminDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
    }
}
