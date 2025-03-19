using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.UserSettingRepository
{
    public class UserSettingWriteRepository : WriteRepository<UserSetting, ResultUserSettingDto, Guid>, IUserSettingWriteRepository
    {
        public UserSettingWriteRepository(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }
    }
}
