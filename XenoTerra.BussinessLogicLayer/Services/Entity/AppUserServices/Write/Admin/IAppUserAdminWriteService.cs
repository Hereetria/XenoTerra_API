using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.AppUserServices.Write.Admin
{
    public interface IAppUserAdminWriteService
    {
        Task<AppUser> CreateAsync(RegisterDto dto);
        Task<AppUser> UpdateAsync(UpdateAppUserAdminDto dto, IEnumerable<string> modifiedFields);
        Task<AppUser> DeleteAsync(Guid id);
    }
}
