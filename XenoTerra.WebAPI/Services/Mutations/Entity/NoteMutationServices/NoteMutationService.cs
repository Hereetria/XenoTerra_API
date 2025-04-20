using AutoMapper;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.NoteMutationServices
{
    public class NoteMutationService(IMapper mapper)
        : MutationService<Note, ResultNoteDto, CreateNoteDto, UpdateNoteDto, Guid>(mapper),
        INoteMutationService
    {
    }
}
