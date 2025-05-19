using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserPostTagServices
{
    public interface IUserPostTagReadService : IReadService<UserPostTag, Guid>
    {
    }
}
