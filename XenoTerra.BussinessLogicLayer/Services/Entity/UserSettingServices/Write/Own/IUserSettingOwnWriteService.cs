using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingServices.Write.Own
{
    public interface IUserSettingOwnWriteService
    {
        Task<UserSetting> UpdateUserSettingAsync(UpdateUserSettingOwnDto updateDto, IEnumerable<string> modifiedFields);
        Task<UserSetting> DeleteUserSettingAsync(Guid key);
    }
}
