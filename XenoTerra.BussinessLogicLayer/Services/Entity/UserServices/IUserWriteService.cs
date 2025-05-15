using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserService
{
    public interface IUserWriteService
    {
        Task<User> CreateAsync(RegisterDto dto);
        Task<User> UpdateAsync(UpdateUserDto dto, IEnumerable<string> modifiedFields);
        Task<User> DeleteAsync(Guid id);
    }
}
