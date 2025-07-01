using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.NoteResolvers;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.NoteQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries.Filters;
using XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class NoteOwnQuery(IMapper mapper, IQueryResolverHelper<Note, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Note, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(NoteOwnFilterType))]
        [UseSorting(typeof(NoteOwnSortType))]
        public async Task<NoteOwnConnection> GetAllNotesAsync(
            [Service] INoteQueryService service,
            [Service] INoteResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetAllQueryable(context, filter);

            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Note, ResultNoteWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<NoteOwnConnection, ResultNoteWithRelationsOwnDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(NoteOwnFilterType))]
        [UseSorting(typeof(NoteOwnSortType))]
        public async Task<NoteOwnConnection> GetNotesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] INoteQueryService service,
            [Service] INoteResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetByIdsQueryable(parsedKeys, context, filter);

            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Note, ResultNoteWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<NoteOwnConnection, ResultNoteWithRelationsOwnDto>(connection);
        }

        public async Task<ResultNoteWithRelationsOwnDto?> GetNoteByIdAsync(
            string? key,
            [Service] INoteQueryService service,
            [Service] INoteResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var filter = BuildAccessFilterAsync(httpContextAccessor);

            var query = service.GetByIdQueryable(parsedKey, context, filter);

            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultNoteWithRelationsOwnDto>(entity);
        }

        private static Expression<Func<Note, bool>> BuildAccessFilterAsync(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            return FilterExpressionHelper.BuildEqualsExpression<Note, Guid>(
                b => b.UserId,
                currentUserId
            );
        }
    }
}
