using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.ViewStoryService;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.ViewStoryQueries
{
    public class ViewStoryQuery
    {
        public async Task<IEnumerable<ResultViewStoryWithRelationsDto>> GetAllViewStoriesAsync(
            [Service] IViewStoryReadService viewStoryReadService,
            [Service] ViewStoryResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = viewStoryReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<ViewStory>().AsQueryable();

            var viewStories = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(viewStories, context);

            return mapper.Map<List<ResultViewStoryWithRelationsDto>>(viewStories);
        }

        public async Task<IEnumerable<ResultViewStoryWithRelationsDto>> GetViewStoriesByIdsAsync(
            [Service] IViewStoryReadService viewStoryReadService,
            [Service] ViewStoryResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = viewStoryReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<ViewStory>().AsQueryable();

            var viewStories = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(viewStories, context);

            return mapper.Map<List<ResultViewStoryWithRelationsDto>>(viewStories);
        }

        public async Task<ResultViewStoryWithRelationsDto> GetViewStoryByIdAsync(
            [Service] IViewStoryReadService viewStoryReadService,
            [Service] ViewStoryResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = viewStoryReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<ViewStory>().AsQueryable();

            var viewStory = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"ViewStory with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(viewStory, context);

            return mapper.Map<ResultViewStoryWithRelationsDto>(viewStory);
        }

    }
}