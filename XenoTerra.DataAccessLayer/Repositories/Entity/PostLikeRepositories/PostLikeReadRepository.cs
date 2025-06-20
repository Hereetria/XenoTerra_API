using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.PostLikeRepositories
{
    public class PostLikeReadRepository(AppDbContext context) : ReadRepository<PostLike, Guid>(context), IPostLikeReadRepository
    {
    }
}
