using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.ViewStoryRepository
{
    public class ViewStoryReadRepository : ReadRepository<ViewStory, Guid>, IViewStoryReadRepository
    {
        public ViewStoryReadRepository(AppDbContext context) : base(context) { }
    }

}
