using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryService;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.StoryQueries
{
    public class StoryQuery
    {
        public async Task<IEnumerable<ResultStoryWithRelationsDto>> GetAllStoriesAsync(
           [Service] IStoryReadService storyReadService,
           [Service] StoryResolver resolver,
           [Service] IMapper mapper,
           IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = storyReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<Story>().AsQueryable();

            var stories = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(stories, context);

            return mapper.Map<List<ResultStoryWithRelationsDto>>(stories);
        }

        public async Task<IEnumerable<ResultStoryWithRelationsDto>> GetStoriesByIdsAsync(
            [Service] IStoryReadService storyReadService,
            [Service] StoryResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = storyReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<Story>().AsQueryable();

            var stories = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(stories, context);

            return mapper.Map<List<ResultStoryWithRelationsDto>>(stories);
        }

        public async Task<ResultStoryWithRelationsDto> GetStoryByIdAsync(
            [Service] IStoryReadService storyReadService,
            [Service] StoryResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = storyReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<Story>().AsQueryable();

            var story = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"Story with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(story, context);

            return mapper.Map<ResultStoryWithRelationsDto>(story);
        }

    }
}
