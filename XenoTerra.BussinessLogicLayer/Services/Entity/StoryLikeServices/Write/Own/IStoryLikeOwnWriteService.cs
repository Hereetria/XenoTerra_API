using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.StoryLikeAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryLikeServices.Write.Own
{
    public interface IStoryLikeOwnWriteService : IWriteService<StoryLike, CreateStoryLikeOwnDto, UpdateStoryLikeOwnDto, Guid> { }

}
