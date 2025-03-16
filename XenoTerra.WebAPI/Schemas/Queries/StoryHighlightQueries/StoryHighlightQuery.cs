using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryHighlightService;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.StoryHighlightQueries
{
    public class StoryHighlightQuery
    {
        public async Task<IEnumerable<ResultStoryHighlightWithRelationsDto>> GetAllStoryHighlightsAsync(
            [Service] IStoryHighlightReadService storyHighlightReadService,
            [Service] StoryHighlightResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = storyHighlightReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<StoryHighlight>().AsQueryable();

            var storyHighlights = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(storyHighlights, context);

            return mapper.Map<List<ResultStoryHighlightWithRelationsDto>>(storyHighlights);
        }

        public async Task<IEnumerable<ResultStoryHighlightWithRelationsDto>> GetStoryHighlightsByIdsAsync(
            [Service] IStoryHighlightReadService storyHighlightReadService,
            [Service] StoryHighlightResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = storyHighlightReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<StoryHighlight>().AsQueryable();

            var storyHighlights = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(storyHighlights, context);

            return mapper.Map<List<ResultStoryHighlightWithRelationsDto>>(storyHighlights);
        }

        public async Task<ResultStoryHighlightWithRelationsDto> GetStoryHighlightByIdAsync(
            [Service] IStoryHighlightReadService storyHighlightReadService,
            [Service] StoryHighlightResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = storyHighlightReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<StoryHighlight>().AsQueryable();

            var storyHighlight = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"StoryHighlight with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(storyHighlight, context);

            return mapper.Map<ResultStoryHighlightWithRelationsDto>(storyHighlight);
        }

    }
}
