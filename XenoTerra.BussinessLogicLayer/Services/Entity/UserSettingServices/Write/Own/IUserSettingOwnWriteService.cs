using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.UserSettingAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingServices.Write.Own
{
    public interface IUserSettingOwnWriteService : IWriteService<UserSetting, CreateUserSettingOwnDto, UpdateUserSettingOwnDto, Guid> { }

}
