

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.UserSettingServices
{
    
    public class UserSettingServiceDAL : GenericRepositoryDAL<UserSetting, ResultUserSettingDto, ResultUserSettingByIdDto, CreateUserSettingDto, UpdateUserSettingDto, Guid>, IUserSettingServiceDAL

    {

        public UserSettingServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}