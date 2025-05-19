using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.NoteDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.NoteServices
{

    public interface INoteReadService : IReadService<Note, Guid> { }

}
