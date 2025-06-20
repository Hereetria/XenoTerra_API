using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.NoteQueryServices
{
    public interface INoteQueryService : IQueryService<Note, Guid>
    {
    }

}
