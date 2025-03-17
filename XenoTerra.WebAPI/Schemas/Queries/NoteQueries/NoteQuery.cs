using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.NoteService;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.NoteResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.NoteQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.NoteQueries
{
    public class NoteQuery
    {
        private readonly IMapper _mapper;

        public NoteQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultNoteWithRelationsDto>> GetAllNotesAsync(
            [Service] INoteQueryService service,
            [Service] INoteResolver resolver,
            IResolverContext context)
        {
            var notes = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(notes, context);
            var noteDtos = _mapper.Map<List<ResultNoteWithRelationsDto>>(notes);
            return noteDtos;
        }

        public async Task<IEnumerable<ResultNoteWithRelationsDto>> GetNotesByIdsAsync(
            [Service] INoteQueryService service,
            [Service] INoteResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var notes = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(notes, context);
            var noteDtos = _mapper.Map<List<ResultNoteWithRelationsDto>>(notes);
            return noteDtos;
        }

        public async Task<ResultNoteWithRelationsDto> GetNoteByIdAsync(
            [Service] INoteQueryService service,
            [Service] INoteResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var note = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(note, context);
            var noteDto = _mapper.Map<ResultNoteWithRelationsDto>(note);
            return noteDto;
        }
    }

}
