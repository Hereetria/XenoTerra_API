using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingServices.Write.Admin
{
    public interface IUserSettingAdminWriteService : IWriteService<UserSetting, CreateUserSettingAdminDto, UpdateUserSettingAdminDto, Guid> { }

}
