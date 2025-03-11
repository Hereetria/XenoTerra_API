using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Entity.MediaRepository;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.HighlightStoryRepository
{
    public class StoryHighlightWriteRepository : WriteRepository<StoryHighlight, Guid>, IStoryHighlightWriteRepository
    {
        public StoryHighlightWriteRepository(AppDbContext context) : base(context) { }
    }
}
