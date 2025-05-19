using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Resolvers.Entity.MessageResolvers;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Queries.Entity.MessageQueryServices;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers.Abstract;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries
{
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class MessageAdminQuery(IMapper mapper, IQueryResolverHelper<Message, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Message, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(MessageAdminFilterType))]
        [UseSorting(typeof(MessageAdminSortType))]
        public async Task<MessageAdminConnection> GetAllMessagesAsync(
            [Service] IMessageQueryService service,
            [Service] IMessageResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Message, ResultMessageWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<MessageAdminConnection, ResultMessageWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(MessageAdminFilterType))]
        [UseSorting(typeof(MessageAdminSortType))]
        public async Task<MessageAdminConnection> GetMessagesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IMessageQueryService service,
            [Service] IMessageResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityAdminConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Message, ResultMessageWithRelationsDto>(
                entityAdminConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<MessageAdminConnection, ResultMessageWithRelationsDto>(connection);
        }

        public async Task<ResultMessageWithRelationsDto?> GetMessageByIdAsync(
            string? key,
            [Service] IMessageQueryService service,
            [Service] IMessageResolver resolver,
            IResolverContext context)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var query = service.GetByIdQueryable(parsedKey, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);

            return entity is null ? null : _mapper.Map<ResultMessageWithRelationsDto>(entity);
        }
    }
}
