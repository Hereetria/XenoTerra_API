using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Write;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserService
{
    public class UserWriteService : WriteService<User, ResultUserDto, CreateUserDto, UpdateUserDto, Guid>, IUserWriteService
    {
        public UserWriteService(IWriteRepository<User, ResultUserDto, Guid> repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}
