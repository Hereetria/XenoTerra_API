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
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryHighlightService
{
    public class StoryHighlightReadService : ReadService<StoryHighlight, ResultStoryHighlightWithRelationsDto, Guid>, IStoryHighlightReadService
    {
        public StoryHighlightReadService(IReadRepository<StoryHighlight, Guid> repository, IMapper mapper, SelectorExpressionProvider<StoryHighlight, ResultStoryHighlightWithRelationsDto> selectorExpressionProvider)
            : base(repository, mapper, selectorExpressionProvider) { }
    }

}
