using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Queries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Queries.Paginations;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Queries.Sorts;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.MessageResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.MessageQueryServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Queries
{
    public class MessageQuery(IMapper mapper, IQueryResolverHelper<Message, Guid> queryResolver)
    {
        private readonly IMapper _mapper = mapper;
        private readonly IQueryResolverHelper<Message, Guid> _queryResolver = queryResolver;

        [UseCustomPaging]
        [UseFiltering(typeof(MessageFilterType))]
        [UseSorting(typeof(MessageSortType))]
        public async Task<MessageConnection> GetAllMessagesAsync(
            [Service] IMessageQueryService service,
            [Service] IMessageResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Message, ResultMessageWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<MessageConnection, ResultMessageWithRelationsDto>(connection);
        }

        [UseCustomPaging]
        [UseFiltering(typeof(MessageFilterType))]
        [UseSorting(typeof(MessageSortType))]
        public async Task<MessageConnection> GetMessagesByIdsAsync(
            IEnumerable<string>? keys,
            [Service] IMessageQueryService service,
            [Service] IMessageResolver resolver,
            IResolverContext context)
        {
            var parsedKeys = GuidParser.ParseGuidOrThrow(keys, nameof(keys));

            var query = service.GetByIdsQueryable(parsedKeys, context);
            var entityConnection = await _queryResolver.ResolveEntityConnectionAsync(query, resolver, context);

            var connection = ConnectionMapper.MapConnection<Message, ResultMessageWithRelationsDto>(
                entityConnection,
                _mapper
            );

            return GraphQLConnectionFactory.Create<MessageConnection, ResultMessageWithRelationsDto>(connection);
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
