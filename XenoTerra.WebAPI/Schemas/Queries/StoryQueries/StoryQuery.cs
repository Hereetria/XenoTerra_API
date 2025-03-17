using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryService;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.StoryResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.StoryQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.StoryQueries
{
    public class StoryQuery
    {
        private readonly IMapper _mapper;

        public StoryQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultStoryWithRelationsDto>> GetAllStoriesAsync(
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            IResolverContext context)
        {
            var stories = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(stories, context);
            var storyDtos = _mapper.Map<List<ResultStoryWithRelationsDto>>(stories);
            return storyDtos;
        }

        public async Task<IEnumerable<ResultStoryWithRelationsDto>> GetStoriesByIdsAsync(
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var stories = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(stories, context);
            var storyDtos = _mapper.Map<List<ResultStoryWithRelationsDto>>(stories);
            return storyDtos;
        }

        public async Task<ResultStoryWithRelationsDto> GetStoryByIdAsync(
            [Service] IStoryQueryService service,
            [Service] IStoryResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var story = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(story, context);
            var storyDto = _mapper.Map<ResultStoryWithRelationsDto>(story);
            return storyDto;
        }
    }

}
