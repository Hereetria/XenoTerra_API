using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.StoryRepository
{
    public interface IStoryWriteRepository : IWriteRepository<Story, Guid>
    {
    }
}
