using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryServices.Write.Own
{
    public interface IStoryOwnWriteService
    {
        Task<Story> CreateStoryAsync(CreateStoryOwnDto createDto);
        Task<Story> DeleteStoryAsync(Guid key);
    }
}
