using AutoMapper;
using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Resolvers;using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.HighlightQueries
{
    public class HighlightQuery
    {
        public async Task<IEnumerable<ResultHighlightWithRelationsDto>> GetAllHighlightsAsync(
            [Service] IHighlightReadService highlightReadService,
            [Service] HighlightResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = highlightReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<Highlight>().AsQueryable();

            var highlights = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(highlights, context);

            return mapper.Map<List<ResultHighlightWithRelationsDto>>(highlights);
        }

        public async Task<IEnumerable<ResultHighlightWithRelationsDto>> GetHighlightsByIdsAsync(
            [Service] IHighlightReadService highlightReadService,
            [Service] HighlightResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = highlightReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<Highlight>().AsQueryable();

            var highlights = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(highlights, context);

            return mapper.Map<List<ResultHighlightWithRelationsDto>>(highlights);
        }

        public async Task<ResultHighlightWithRelationsDto> GetHighlightByIdAsync(
            [Service] IHighlightReadService highlightReadService,
            [Service] HighlightResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = highlightReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<Highlight>().AsQueryable();

            var highlight = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"Highlight with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(highlight, context);

            return mapper.Map<ResultHighlightWithRelationsDto>(highlight);
        }

    }
}
