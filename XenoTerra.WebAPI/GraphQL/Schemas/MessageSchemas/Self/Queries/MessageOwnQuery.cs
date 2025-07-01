using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.MessageResolvers;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.MessageQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries.Paginations.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries.Sorts;
using XenoTerra.DTOLayer.Dtos.MessageDtos.Self.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class MessageOwnQuery(IMapper mapper, IQueryResolverHelper<Message, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Message, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(MessageOwnFilterType))]
        [UseSorting(typeof(MessageOwnSortType))]
        public async Task<MessageOwnConnection> GetAllMessagesAsync(
            [Service] IMessageQueryService service,
            [Service] IMessageResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = BuildAccessFilter(httpContextAccessor);
            var query = service.GetAllQueryable(context, filter);

            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Message, ResultMessageWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<MessageOwnConnection, ResultMessageWithRelationsOwnDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(MessageOwnFilterType))]
        [UseSorting(typeof(MessageOwnSortType))]
        public async Task<MessageOwnConnection> GetMessagesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IMessageQueryService service,
            [Service] IMessageResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var filter = BuildAccessFilter(httpContextAccessor);
            var query = service.GetByIdsQueryable(parsedKeys, context, filter);

            var entityOwnConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Message, ResultMessageWithRelationsOwnDto>(
                entityOwnConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<MessageOwnConnection, ResultMessageWithRelationsOwnDto>(connection);
        }

        public async Task<ResultMessageWithRelationsOwnDto?> GetMessageByIdAsync(
            string? key,
            [Service] IMessageQueryService service,
            [Service] IMessageResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var filter = BuildAccessFilter(httpContextAccessor);
            var query = service.GetByIdQueryable(parsedKey, context, filter);

            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultMessageWithRelationsOwnDto>(entity);
        }

        private static Expression<Func<Message, bool>> BuildAccessFilter(IHttpContextAccessor httpContextAccessor)
        {
            var currentUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            return FilterExpressionHelper.BuildMultiEqualsOrExpression<Message, Guid>(
                [
                    m => m.SenderId,
                    m => m.ReceiverId
                ],
                currentUserId);

        }
    }
}
