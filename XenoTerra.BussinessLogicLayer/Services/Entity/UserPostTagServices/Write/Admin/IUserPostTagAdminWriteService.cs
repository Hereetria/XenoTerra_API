using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserPostTagServices.Write.Admin
{
    public interface IUserPostTagAdminWriteService : IWriteService<UserPostTag, CreateUserPostTagAdminDto, UpdateUserPostTagAdminDto, Guid>
    {
    }
}
