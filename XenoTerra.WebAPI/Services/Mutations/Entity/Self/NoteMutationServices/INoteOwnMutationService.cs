using XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.NoteMutationServices
{
    public interface INoteOwnMutationService : IMutationService<Note, ResultNoteOwnDto, CreateNoteOwnDto, UpdateNoteOwnDto, Guid>
    {
    }
}
