using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.CommentResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.CommentQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class CommentAdminQuery(IMapper mapper, IQueryResolverHelper<Comment, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Comment, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(CommentAdminFilterType))]
        [UseSorting(typeof(CommentAdminSortType))]
        public async Task<CommentAdminConnection> GetAllCommentsAsync(
            [Service] ICommentQueryService service,
            [Service] ICommentResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Comment, ResultCommentWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<CommentAdminConnection, ResultCommentWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(CommentAdminFilterType))]
        [UseSorting(typeof(CommentAdminSortType))]
        public async Task<CommentAdminConnection> GetCommentsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] ICommentQueryService service,
            [Service] ICommentResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Comment, ResultCommentWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<CommentAdminConnection, ResultCommentWithRelationsDto>(connection);
        }

        public async Task<ResultCommentWithRelationsDto?> GetCommentByIdAsync(
            string? key,
            [Service] ICommentQueryService service,
            [Service] ICommentResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultCommentWithRelationsDto>(entity);
        }
    }
}
