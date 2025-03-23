using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.SavedPostRepository
{
    public class SavedPostReadRepository : ReadRepository<SavedPost, Guid>, ISavedPostReadRepository
    {
        public SavedPostReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
