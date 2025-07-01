using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.FollowDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.FollowServices.Write.Own
{
    public interface IFollowOwnWriteService : IWriteService<Follow, CreateFollowOwnDto, UpdateFollowOwnDto, Guid> { }

}
