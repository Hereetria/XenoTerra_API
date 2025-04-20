using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserPostTagServices
{
    public interface IUserPostTagWriteService : IWriteService<UserPostTag, CreateUserPostTagDto, UpdateUserPostTagDto, Guid>
    {
    }
}
