using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.Entity.NoteService;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.NoteQueries
{
    public class NoteQuery
    {
        public async Task<IEnumerable<ResultNoteWithRelationsDto>> GetAllNotesAsync(
            [Service] INoteReadService noteReadService,
            [Service] NoteResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = noteReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<Note>().AsQueryable();

            var notes = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(notes, context);

            return mapper.Map<List<ResultNoteWithRelationsDto>>(notes);
        }

        public async Task<IEnumerable<ResultNoteWithRelationsDto>> GetNotesByIdsAsync(
            [Service] INoteReadService noteReadService,
            [Service] NoteResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = noteReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<Note>().AsQueryable();

            var notes = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(notes, context);

            return mapper.Map<List<ResultNoteWithRelationsDto>>(notes);
        }

        public async Task<ResultNoteWithRelationsDto> GetNoteByIdAsync(
            [Service] INoteReadService noteReadService,
            [Service] NoteResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = noteReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<Note>().AsQueryable();

            var note = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"Note with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(note, context);

            return mapper.Map<ResultNoteWithRelationsDto>(note);
        }

    }
}
