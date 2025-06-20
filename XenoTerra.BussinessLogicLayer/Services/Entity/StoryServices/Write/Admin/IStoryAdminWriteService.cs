using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.StoryAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryServices.Write.Admin
{
    public interface IStoryAdminWriteService : IWriteService<Story, CreateStoryAdminDto, UpdateStoryAdminDto, Guid> { }

}
