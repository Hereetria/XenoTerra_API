using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.NoteRepository
{
    public interface INoteReadRepository : IReadRepository<Note, Guid>
    {
    }
}
