using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.NoteMutationServices
{
    public interface INoteSelfMutationService : IMutationService<Note, ResultNoteDto, CreateNoteDto, UpdateNoteDto, Guid>
    {
    }
}
