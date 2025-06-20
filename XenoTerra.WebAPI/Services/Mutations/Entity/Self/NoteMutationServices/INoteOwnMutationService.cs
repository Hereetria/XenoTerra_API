using XenoTerra.DTOLayer.Dtos.NoteAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.NoteMutationServices
{
    public interface INoteOwnMutationService : IMutationService<Note, ResultNoteOwnDto, CreateNoteOwnDto, UpdateNoteOwnDto, Guid>
    {
    }
}
