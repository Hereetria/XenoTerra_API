using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.AppUserDtos.Self.Own;
using XenoTerra.DTOLayer.Dtos.AuthDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.AppUserServices.Write.Own
{
    public interface IAppUserOwnWriteService
    {
        Task<AppUser> CreateAsync(RegisterDto dto);
        Task<AppUser> UpdateAsync(UpdateAppUserOwnDto dto, IEnumerable<string> modifiedFields);
        Task<AppUser> DeleteAsync(Guid id);
    }
}
