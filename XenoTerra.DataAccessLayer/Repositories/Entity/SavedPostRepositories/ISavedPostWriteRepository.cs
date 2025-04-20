using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.SavedPostRepository
{
    public interface ISavedPostWriteRepository : IWriteRepository<SavedPost, Guid>
    {
    }
}
