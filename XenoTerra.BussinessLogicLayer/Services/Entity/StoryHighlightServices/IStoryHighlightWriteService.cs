using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryHighlightServices
{
    public interface IStoryHighlightWriteService : IWriteService<StoryHighlight, CreateStoryHighlightDto, UpdateStoryHighlightDto, Guid>
    {
    }
}
