using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.MessageResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.MessageQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Queries
{
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
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapSelfConnection<Message, ResultMessageWithRelationsDto>(
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
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entitySelfConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapSelfConnection<Message, ResultMessageWithRelationsDto>(
                entitySelfConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<MessageSelfConnection, ResultMessageWithRelationsDto>(connection);
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

            return _mapper.Map<ResultMessageWithRelationsDto>(entity);
        }
    }
}
