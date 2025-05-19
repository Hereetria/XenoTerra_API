using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.NoteMutationServices
{
    public interface INoteAdminMutationService : IMutationService<Note, ResultNoteDto, CreateNoteDto, UpdateNoteDto, Guid>
    {
    }
}
