using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.ReactionResolvers;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.ReactionQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Queries.Filters;
using XenoTerra.DTOLayer.Dtos.ReactionDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ReactionOwnQuery(IMapper mapper, IQueryResolverHelper<Reaction, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Reaction, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(ReactionOwnFilterType))]
        [UseSorting(typeof(ReactionOwnSortType))]
        public async Task<ReactionOwnConnection> GetAllReactionsAsync(
            [Service] IReactionQueryService service,
            [Service] IReactionResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = CreateReactionAccessFilter(httpContextAccessor);
            var query = service.GetAllQueryable(context, filter);

            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Reaction, ResultReactionWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ReactionOwnConnection, ResultReactionWithRelationsOwnDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(ReactionOwnFilterType))]
        [UseSorting(typeof(ReactionOwnSortType))]
        public async Task<ReactionOwnConnection> GetReactionsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IReactionQueryService service,
            [Service] IReactionResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var filter = CreateReactionAccessFilter(httpContextAccessor);
            var query = service.GetByIdsQueryable(parsedKeys, context, filter);

            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Reaction, ResultReactionWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ReactionOwnConnection, ResultReactionWithRelationsOwnDto>(connection);
        }

        public async Task<ResultReactionWithRelationsOwnDto?> GetReactionByIdAsync(
            string? key,
            [Service] IReactionQueryService service,
            [Service] IReactionResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var filter = CreateReactionAccessFilter(httpContextAccessor);
            var query = service.GetByIdQueryable(parsedKey, context, filter);

            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultReactionWithRelationsOwnDto>(entity);
        }

        private static Expression<Func<Reaction, bool>> CreateReactionAccessFilter(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            return FilterExpressionHelper.BuildEqualsOrEqualsExpression<Reaction, Guid>(
                x => x.Message.SenderId,
                x => x.Message.ReceiverId,
                currentUserId
            );
        }
    }
}
