using AutoMapper;
using XenoTerra.DTOLayer.Dtos.NoteAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.NoteMutationServices
{
    public class NoteOwnMutationService(IMapper mapper)
        : MutationService<Note, ResultNoteOwnDto, CreateNoteOwnDto, UpdateNoteOwnDto, Guid>(mapper),
        INoteOwnMutationService
    {
    }
}
