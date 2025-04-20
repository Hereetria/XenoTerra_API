using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.NoteMutationServices
{
    public interface INoteMutationService : IMutationService<Note, ResultNoteDto, CreateNoteDto, UpdateNoteDto, Guid>
    {
    }
}
