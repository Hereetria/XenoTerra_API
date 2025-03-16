using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.StoryHighlightRepository
{
    public interface IStoryHighlightReadRepository : IReadRepository<StoryHighlight, Guid> 
    {
        public IQueryable<Story> GetStoriesByHighlightIdsQueryable(IEnumerable<Guid> keys);
        public IQueryable<Story> GetStoryByHighlightIdQueryable(Guid key);
        public IQueryable<Highlight> GetHighlightsByStoryIdsQueryable(IEnumerable<Guid> keys);
        public IQueryable<Highlight> GetHighlightByStoryIdQueryable(Guid key);
    }


}
