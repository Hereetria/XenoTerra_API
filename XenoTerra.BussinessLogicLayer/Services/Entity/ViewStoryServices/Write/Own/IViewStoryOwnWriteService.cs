using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ViewStoryServices.Write.Own
{
    public interface IViewStoryOwnWriteService : IWriteService<ViewStory, CreateViewStoryOwnDto, UpdateViewStoryOwnDto, Guid> { }

}
