

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.UserServices
{
    
    public class UserServiceDAL : GenericRepositoryDAL<User, ResultUserDto, ResultUserByIdDto, CreateUserDto, UpdateUserDto, Guid>, IUserServiceDAL

    {

        public UserServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}