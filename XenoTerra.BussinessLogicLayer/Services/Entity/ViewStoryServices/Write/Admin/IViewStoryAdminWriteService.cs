using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ViewStoryServices.Write.Admin
{
    public interface IViewStoryAdminWriteService : IWriteService<ViewStory, CreateViewStoryAdminDto, UpdateViewStoryAdminDto, Guid> { }

}
