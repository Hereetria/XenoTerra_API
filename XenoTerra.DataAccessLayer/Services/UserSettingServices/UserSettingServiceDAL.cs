

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.UserSettingServices
{
    
    public class UserSettingServiceDAL : GenericRepositoryDAL<UserSetting, ResultUserSettingDto, ResultUserSettingWithRelationsDto, CreateUserSettingDto, UpdateUserSettingDto, Guid>, IUserSettingServiceDAL

    {

        public UserSettingServiceDAL(AppDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}