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
    }


}
