using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryHighlightServices.Write.Admin
{
    public interface IStoryHighlightAdminWriteService : IWriteService<StoryHighlight, CreateStoryHighlightAdminDto, UpdateStoryHighlightAdminDto, Guid>
    {
    }
}
