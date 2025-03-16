using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Entity.MediaRepository;
using XenoTerra.DataAccessLayer.Repositories.Entity.StoryHighlightRepository;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.HighlightStoryRepository
{
    public class StoryHighlightReadRepository : ReadRepository<StoryHighlight, Guid>, IStoryHighlightReadRepository
    {
        public StoryHighlightReadRepository(AppDbContext context) : base(context) { }

        public IQueryable<Story> GetStoryByHighlightIdQueryable(Guid key)
        {
            if (key == Guid.Empty)
                throw new ArgumentException("Key cannot be empty.", nameof(key));

            return _context.StoryHighlights
                .AsNoTracking()
                .Where(sh => sh.HighlightId == key)
                .Select(sh => sh.Story)
                .Distinct();
        }

        public IQueryable<Story> GetStoriesByHighlightIdsQueryable(IEnumerable<Guid> keys)
        {
            if (keys is null || !keys.Any())
                throw new ArgumentException("At least one ID must be provided.", nameof(keys));

            var keySet = new HashSet<Guid>(keys);

            return _context.StoryHighlights
                .AsNoTracking()
                .Where(sh => keySet.Contains(sh.HighlightId))
                .Select(sh => sh.Story)
                .Distinct();
        }

        public IQueryable<Highlight> GetHighlightByStoryIdQueryable(Guid key)
        {
            if (key == Guid.Empty)
                throw new ArgumentException("Key cannot be empty.", nameof(key));

            return _context.StoryHighlights
                .AsNoTracking()
                .Where(sh => sh.StoryId == key)
                .Select(sh => sh.Highlight)
                .Distinct();
        }

        public IQueryable<Highlight> GetHighlightsByStoryIdsQueryable(IEnumerable<Guid> keys)
        {
            if (keys is null || !keys.Any())
                throw new ArgumentException("At least one ID must be provided.", nameof(keys));

            var keySet = new HashSet<Guid>(keys);

            return _context.StoryHighlights
                .AsNoTracking()
                .Where(sh => keySet.Contains(sh.StoryId))
                .Select(sh => sh.Highlight)
                .Distinct();
        }

    }


}
