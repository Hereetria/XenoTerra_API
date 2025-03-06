
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.BussinessLogicLayer.Services.UserSettingServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.UserSettingServices
{
     public class UserSettingServiceBLL : GenericRepositoryBLL<UserSetting, ResultUserSettingDto, ResultUserSettingWithRelationsDto, CreateUserSettingDto, UpdateUserSettingDto, Guid>, IUserSettingServiceBLL
    {
        public UserSettingServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}