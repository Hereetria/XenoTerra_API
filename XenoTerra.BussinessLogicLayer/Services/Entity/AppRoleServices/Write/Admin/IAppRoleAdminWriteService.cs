using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.AppRoleDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.AppRoleServices.Write.Admin
{
    public interface IAppRoleAdminWriteService
    {
        Task<AppRole> CreateAsync(CreateAppRoleAdminDto dto);
        Task<AppRole> UpdateAsync(UpdateAppRoleAdminDto dto, IEnumerable<string> modifiedFields);
        Task<AppRole> DeleteAsync(Guid id);
    }
}
