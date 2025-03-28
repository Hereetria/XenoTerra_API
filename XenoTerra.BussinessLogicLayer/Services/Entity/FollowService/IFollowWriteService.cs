using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.FollowService
{
    public interface IFollowWriteService : IWriteService<Follow, CreateFollowDto, UpdateFollowDto, Guid> { }

}
