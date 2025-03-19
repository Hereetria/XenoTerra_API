using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.NoteQueryServices
{
    public class NoteQueryService : QueryService<Note, ResultNoteWithRelationsDto, Guid>, INoteQueryService
    {
        public NoteQueryService(IReadService<Note, ResultNoteWithRelationsDto, Guid> readService, IMapper mapper)
            : base(readService, mapper)
        {
        }
    }
}
