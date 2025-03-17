using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.ViewStoryService;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ViewStoryResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.ViewStoryQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.ViewStoryQueries
{
    public class ViewStoryQuery
    {
        private readonly IMapper _mapper;

        public ViewStoryQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultViewStoryWithRelationsDto>> GetAllViewStoriesAsync(
            [Service] IViewStoryQueryService service,
            [Service] IViewStoryResolver resolver,
            IResolverContext context)
        {
            var viewStories = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(viewStories, context);
            var viewStoryDtos = _mapper.Map<List<ResultViewStoryWithRelationsDto>>(viewStories);
            return viewStoryDtos;
        }

        public async Task<IEnumerable<ResultViewStoryWithRelationsDto>> GetViewStoriesByIdsAsync(
            [Service] IViewStoryQueryService service,
            [Service] IViewStoryResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var viewStories = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(viewStories, context);
            var viewStoryDtos = _mapper.Map<List<ResultViewStoryWithRelationsDto>>(viewStories);
            return viewStoryDtos;
        }

        public async Task<ResultViewStoryWithRelationsDto> GetViewStoryByIdAsync(
            [Service] IViewStoryQueryService service,
            [Service] IViewStoryResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var viewStory = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(viewStory, context);
            var viewStoryDto = _mapper.Map<ResultViewStoryWithRelationsDto>(viewStory);
            return viewStoryDto;
        }
    }

}