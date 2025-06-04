using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.AppUserDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.AppUserServices
{
    public interface IAppUserWriteService
    {
        Task<AppUser> CreateAsync(RegisterDto dto);
        Task<AppUser> UpdateAsync(UpdateAppUserDto dto, IEnumerable<string> modifiedFields);
        Task<AppUser> DeleteAsync(Guid id);
    }
}
