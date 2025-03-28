using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.NoteQueryServices
{
    public class NoteQueryService : QueryService<Note, Guid>, INoteQueryService
    {
        public NoteQueryService(IReadService<Note, Guid> readService)
            : base(readService)
        {
        }
    }
}
