using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.StoryRepository
{
    public interface IStoryReadRepository : IReadRepository<Story, Guid>
    {
    }
}
