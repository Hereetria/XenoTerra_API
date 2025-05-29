using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.NoteResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.NoteQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class NoteSelfQuery(IMapper mapper, IQueryResolverHelper<Note, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Note, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(NoteSelfFilterType))]
        [UseSorting(typeof(NoteSelfSortType))]
        public async Task<NoteSelfConnection> GetAllNotesAsync(
            [Service] INoteQueryService service,
            [Service] INoteResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider);
            var query = service.GetAllQueryable(context, filter);

            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Note, ResultNoteWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<NoteSelfConnection, ResultNoteWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(NoteSelfFilterType))]
        [UseSorting(typeof(NoteSelfSortType))]
        public async Task<NoteSelfConnection> GetNotesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] INoteQueryService service,
            [Service] INoteResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider);
            var query = service.GetByIdsQueryable(parsedKeys, context, filter);

            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Note, ResultNoteWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<NoteSelfConnection, ResultNoteWithRelationsDto>(connection);
        }

        public async Task<ResultNoteWithRelationsDto?> GetNoteByIdAsync(
            string? key,
            [Service] INoteQueryService service,
            [Service] INoteResolver resolver,
            [Service] IFollowedUserIdProvider followedUserIdProvider,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var filter = await BuildAccessFilterAsync(httpContextAccessor, followedUserIdProvider);
            var query = service.GetByIdQueryable(parsedKey, context, filter);

            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultNoteWithRelationsDto>(entity);
        }

        private static async Task<Expression<Func<Note, bool>>> BuildAccessFilterAsync(
            IHttpContextAccessor httpContextAccessor,
            IFollowedUserIdProvider followedUserIdProvider)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = await followedUserIdProvider.GetFollowedUserIdsAsync();

            var authorizedUserIds = followedUserIds
                .Append(currentUserId)
                .Distinct()
                .ToList();

            return FilterExpressionHelper.BuildContainsExpression<Note, Guid>(
                note => note.UserId,
                authorizedUserIds);
        }
    }
}
