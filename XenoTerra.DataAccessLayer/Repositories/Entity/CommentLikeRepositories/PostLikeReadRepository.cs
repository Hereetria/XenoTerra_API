using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.CommentLikeRepositories
{
    public class CommentLikeReadRepository(AppDbContext context) : ReadRepository<CommentLike, Guid>(context), ICommentLikeReadRepository
    {
    }
}
