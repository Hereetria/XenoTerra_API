using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.SavedPostRepositories
{
    public interface ISavedPostWriteRepository : IWriteRepository<SavedPost, Guid>
    {
    }
}
