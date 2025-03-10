using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Write;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryService
{
    public class StoryWriteService : WriteService<Story, ResultStoryDto, CreateStoryDto, UpdateStoryDto, Guid>, IStoryWriteService
    {
        public StoryWriteService(IWriteRepository<Story, Guid> repository, IMapper mapper, SelectorExpressionProvider<Story, ResultStoryDto> selectorExpressionProvider)
            : base(repository, mapper, selectorExpressionProvider) { }
    }

}
