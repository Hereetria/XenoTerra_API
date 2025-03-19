using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryService
{
    public class StoryReadService : ReadService<Story, ResultStoryWithRelationsDto, Guid>, IStoryReadService
    {
        public StoryReadService(IReadRepository<Story, ResultStoryWithRelationsDto, Guid> repository)
            : base(repository) { }
    }
}
