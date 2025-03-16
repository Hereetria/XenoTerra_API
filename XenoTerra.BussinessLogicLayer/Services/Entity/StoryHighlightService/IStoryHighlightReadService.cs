using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryHighlightService
{
    public interface IStoryHighlightReadService : IReadService<StoryHighlight, Guid> 
    {
        public IQueryable<Story> FetchStoriesByHighlightIdsQueryable(IEnumerable<Guid> keys, IEnumerable<string> selectedProperties);
        public IQueryable<Story> FetchStoryByHighlightIdQueryable(Guid key, IEnumerable<string> selectedProperties);
        public IQueryable<Highlight> FetchHighlightsByStoryIdsQueryable(IEnumerable<Guid> keys, IEnumerable<string> selectedProperties);
        public IQueryable<Highlight> FetchHighlightByStoryIdQueryable(Guid key, IEnumerable<string> selectedProperties);
    }

}
