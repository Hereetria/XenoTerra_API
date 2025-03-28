using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.PostQueries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.PostQueries.Sorts;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.PostResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.PostQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.PostQueries
{
    public class PostQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<Post, Guid> _queryResolver;

        public PostQuery(IMapper mapper, IQueryResolverHelper<Post, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(PostFilterType))]
        [UseSorting(typeof(PostSortType))]
        public async Task<IEnumerable<ResultPostWithRelationsDto>> GetAllPostsAsync(
            [Service] IPostQueryService service,
            [Service] IPostResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultPostWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(PostFilterType))]
        [UseSorting(typeof(PostSortType))]
        public async Task<IEnumerable<ResultPostWithRelationsDto>> GetPostsByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] IPostQueryService service,
            [Service] IPostResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultPostWithRelationsDto>>(entities);
        }

        public async Task<ResultPostWithRelationsDto> GetPostByIdAsync(
            Guid key,
            [Service] IPostQueryService service,
            [Service] IPostResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultPostWithRelationsDto>(entity);
        }
    }
}
