using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.ReactionResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.ReactionQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ReactionSelfQuery(IMapper mapper, IQueryResolverHelper<Reaction, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Reaction, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(ReactionSelfFilterType))]
        [UseSorting(typeof(ReactionSelfSortType))]
        public async Task<ReactionSelfConnection> GetAllReactionsAsync(
            [Service] IReactionQueryService service,
            [Service] IReactionResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = CreateReactionAccessFilter(httpContextAccessor);
            var query = service.GetAllQueryable(context, filter);

            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Reaction, ResultReactionWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ReactionSelfConnection, ResultReactionWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(ReactionSelfFilterType))]
        [UseSorting(typeof(ReactionSelfSortType))]
        public async Task<ReactionSelfConnection> GetReactionsByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IReactionQueryService service,
            [Service] IReactionResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var filter = CreateReactionAccessFilter(httpContextAccessor);
            var query = service.GetByIdsQueryable(parsedKeys, context, filter);

            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Reaction, ResultReactionWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<ReactionSelfConnection, ResultReactionWithRelationsDto>(connection);
        }

        public async Task<ResultReactionWithRelationsDto?> GetReactionByIdAsync(
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

            return entity is null ? null : _mapper.Map<ResultReactionWithRelationsDto>(entity);
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
