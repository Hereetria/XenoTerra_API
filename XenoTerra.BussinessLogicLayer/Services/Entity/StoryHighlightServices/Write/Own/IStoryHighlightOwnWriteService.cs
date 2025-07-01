using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryHighlightServices.Write.Own
{
    public interface IStoryHighlightOwnWriteService : IWriteService<StoryHighlight, CreateStoryHighlightOwnDto, UpdateStoryHighlightOwnDto, Guid>
    {
    }
}
