using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.UserPostTagAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserPostTagServices.Write.Own
{
    public interface IUserPostTagOwnWriteService : IWriteService<UserPostTag, CreateUserPostTagOwnDto, UpdateUserPostTagOwnDto, Guid>
    {
    }
}
