using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.PostLikeResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.PostLikeQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class PostLikeAdminQuery(IMapper mapper, IQueryResolverHelper<PostLike, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<PostLike, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(PostLikeAdminFilterType))]
        [UseSorting(typeof(PostLikeAdminSortType))]
        public async Task<PostLikeAdminConnection> GetAllPostLikesAsync(
            [Service] IPostLikeQueryService service,
            [Service] IPostLikeResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<PostLike, ResultPostLikeWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<PostLikeAdminConnection, ResultPostLikeWithRelationsAdminDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(PostLikeAdminFilterType))]
        [UseSorting(typeof(PostLikeAdminSortType))]
        public async Task<PostLikeAdminConnection> GetPostLikesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IPostLikeQueryService service,
            [Service] IPostLikeResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<PostLike, ResultPostLikeWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<PostLikeAdminConnection, ResultPostLikeWithRelationsAdminDto>(connection);
        }

        public async Task<ResultPostLikeWithRelationsAdminDto?> GetPostLikeByIdAsync(
            string? key,
            [Service] IPostLikeQueryService service,
            [Service] IPostLikeResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultPostLikeWithRelationsAdminDto>(entity);
        }
    }

}
