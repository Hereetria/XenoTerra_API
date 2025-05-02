using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.RoleService
{
    public interface IRoleWriteService
    {
        Task<IdentityRole<Guid>> CreateAsync(CreateRoleDto dto);
        Task<IdentityRole<Guid>> UpdateAsync(UpdateRoleDto dto, IEnumerable<string> modifiedFields);
        Task<IdentityRole<Guid>> DeleteAsync(Guid id);
    }
}
