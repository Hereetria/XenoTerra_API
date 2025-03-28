using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.UserSettingRepository
{
    public class UserSettingReadRepository(AppDbContext context) : ReadRepository<UserSetting, Guid>(context), IUserSettingReadRepository
    {
    }
}
