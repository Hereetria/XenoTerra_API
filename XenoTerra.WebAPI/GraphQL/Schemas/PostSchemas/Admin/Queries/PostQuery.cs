using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.PostResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.PostQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries
{
    public class PostQuery(IMapper mapper, IQueryResolverHelper<Post, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Post, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(PostFilterType))]
        [UseSorting(typeof(PostSortType))]
        public async Task<PostConnection> GetAllPostsAsync(
            [Service] IPostQueryService service,
            [Service] IPostResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Post, ResultPostWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<PostConnection, ResultPostWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(PostFilterType))]
        [UseSorting(typeof(PostSortType))]
        public async Task<PostConnection> GetPostsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IPostQueryService service,
            [Service] IPostResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Post, ResultPostWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<PostConnection, ResultPostWithRelationsDto>(connection);
        }

        public async Task<ResultPostWithRelationsDto?> GetPostByIdAsync(
            string? key,
            [Service] IPostQueryService service,
            [Service] IPostResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return _mapper.Map<ResultPostWithRelationsDto>(entity);
        }
    }
}
