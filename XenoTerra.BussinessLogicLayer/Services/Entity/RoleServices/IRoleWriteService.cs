using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DTOLayer.Dtos.RoleDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.RoleServices
{
    public interface IRoleWriteService
    {
        Task<Role> CreateAsync(CreateRoleDto dto);
        Task<Role> UpdateAsync(UpdateRoleDto dto, IEnumerable<string> modifiedFields);
        Task<Role> DeleteAsync(Guid id);
    }
}
