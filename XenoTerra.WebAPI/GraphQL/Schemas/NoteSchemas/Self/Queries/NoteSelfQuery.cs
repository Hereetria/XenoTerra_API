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
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
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
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = (await followedUserIdProvider.GetFollowedUserIdsAsync()).ToList();

            var filter = CreateNoteAccessFilter(currentUserId, followedUserIds);

            var query = service.GetAllQueryable(context).Where(filter);
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

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = (await followedUserIdProvider.GetFollowedUserIdsAsync()).ToList();

            var filter = CreateNoteAccessFilter(currentUserId, followedUserIds);

            var query = service.GetByIdsQueryable(parsedKeys, context).Where(filter);
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

            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            var followedUserIds = (await followedUserIdProvider.GetFollowedUserIdsAsync()).ToList();

            var filter = CreateNoteAccessFilter(currentUserId, followedUserIds);

            var query = service.GetByIdQueryable(parsedKey, context).Where(filter);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultNoteWithRelationsDto>(entity);
        }

        private static Expression<Func<Note, bool>> CreateNoteAccessFilter(
            Guid currentUserId,
            IReadOnlyCollection<Guid> followedUserIds)
        {
            var authorizedUserIds = followedUserIds
                .Append(currentUserId)
                .Distinct()
                .ToList();

            return note => authorizedUserIds.Contains(note.UserId);
        }
    }
}
