using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.NoteAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.NoteMutationServices
{
    public interface INoteAdminMutationService : IMutationService<Note, ResultNoteAdminDto, CreateNoteAdminDto, UpdateNoteAdminDto, Guid>
    {
    }
}