using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.StoryLikeDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryLikeServices.Write.Admin
{
    public interface IStoryLikeAdminWriteService : IWriteService<StoryLike, CreateStoryLikeAdminDto, UpdateStoryLikeAdminDto, Guid> { }

}
