using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.MessageResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.MessageQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;
using System.Linq.Expressions;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Queries
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class MessageSelfQuery(IMapper mapper, IQueryResolverHelper<Message, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Message, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(MessageSelfFilterType))]
        [UseSorting(typeof(MessageSelfSortType))]
        public async Task<MessageSelfConnection> GetAllMessagesAsync(
            [Service] IMessageQueryService service,
            [Service] IMessageResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var filter = BuildAccessFilter(httpContextAccessor);
            var query = service.GetAllQueryable(context, filter);

            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Message, ResultMessageWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<MessageSelfConnection, ResultMessageWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(MessageSelfFilterType))]
        [UseSorting(typeof(MessageSelfSortType))]
        public async Task<MessageSelfConnection> GetMessagesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IMessageQueryService service,
            [Service] IMessageResolver resolver,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));
            var filter = BuildAccessFilter(httpContextAccessor);
            var query = service.GetByIdsQueryable(parsedKeys, context, filter);

            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Message, ResultMessageWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<MessageSelfConnection, ResultMessageWithRelationsDto>(connection);
        }

        public async Task<ResultMessageWithRelationsDto?> GetMessageByIdAsync(
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

            return entity is null ? null : _mapper.Map<ResultMessageWithRelationsDto>(entity);
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
