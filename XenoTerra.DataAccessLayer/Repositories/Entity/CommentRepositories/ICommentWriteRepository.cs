using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.CommentRepositories
{
    public interface ICommentWriteRepository : IWriteRepository<Comment, Guid>
    {
    }
}
