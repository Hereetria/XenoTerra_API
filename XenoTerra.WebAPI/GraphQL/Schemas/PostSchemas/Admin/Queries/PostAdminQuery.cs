using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.PostResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.PostQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class PostAdminQuery(IMapper mapper, IQueryResolverHelper<Post, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Post, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(PostAdminFilterType))]
        [UseSorting(typeof(PostAdminSortType))]
        public async Task<PostAdminConnection> GetAllPostsAsync(
            [Service] IPostQueryService service,
            [Service] IPostResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Post, ResultPostWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<PostAdminConnection, ResultPostWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(PostAdminFilterType))]
        [UseSorting(typeof(PostAdminSortType))]
        public async Task<PostAdminConnection> GetPostsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IPostQueryService service,
            [Service] IPostResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Post, ResultPostWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<PostAdminConnection, ResultPostWithRelationsDto>(connection);
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

            return entity is null ? null : _mapper.Map<ResultPostWithRelationsDto>(entity);
        }
    }
}
