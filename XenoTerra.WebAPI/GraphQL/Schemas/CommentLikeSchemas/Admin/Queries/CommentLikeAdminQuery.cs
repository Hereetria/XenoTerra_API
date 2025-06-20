using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.CommentLikeResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.CommentLikeQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class CommentLikeAdminQuery(IMapper mapper, IQueryResolverHelper<CommentLike, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<CommentLike, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(CommentLikeAdminFilterType))]
        [UseSorting(typeof(CommentLikeAdminSortType))]
        public async Task<CommentLikeAdminConnection> GetAllCommentLikesAsync(
            [Service] ICommentLikeQueryService service,
            [Service] ICommentLikeResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<CommentLike, ResultCommentLikeWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<CommentLikeAdminConnection, ResultCommentLikeWithRelationsAdminDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(CommentLikeAdminFilterType))]
        [UseSorting(typeof(CommentLikeAdminSortType))]
        public async Task<CommentLikeAdminConnection> GetCommentLikesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] ICommentLikeQueryService service,
            [Service] ICommentLikeResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<CommentLike, ResultCommentLikeWithRelationsAdminDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<CommentLikeAdminConnection, ResultCommentLikeWithRelationsAdminDto>(connection);
        }

        public async Task<ResultCommentLikeWithRelationsAdminDto?> GetCommentLikeByIdAsync(
            string? key,
            [Service] ICommentLikeQueryService service,
            [Service] ICommentLikeResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultCommentLikeWithRelationsAdminDto>(entity);
        }
    }

}
