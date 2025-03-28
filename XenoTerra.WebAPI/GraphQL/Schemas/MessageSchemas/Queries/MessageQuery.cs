using AutoMapper;
using HotChocolate;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.MessageService;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas._Helpers.QueryHelpers;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.MessageQueries.Filters;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.MessageQueries.Sorts;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.MessageResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.MessageQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.MessageQueries
{
    public class MessageQuery
    {
        private readonly IMapper _mapper;
        private readonly IQueryResolverHelper<Message, Guid> _queryResolver;

        public MessageQuery(IMapper mapper, IQueryResolverHelper<Message, Guid> queryResolver)
        {
            _mapper = mapper;
            _queryResolver = queryResolver;
        }

        [UsePaging]
        [UseFiltering(typeof(MessageFilterType))]
        [UseSorting(typeof(MessageSortType))]
        public async Task<IEnumerable<ResultMessageWithRelationsDto>> GetAllMessagesAsync(
            [Service] IMessageQueryService service,
            [Service] IMessageResolver resolver,
            IResolverContext context)
        {
            var query = service.GetAllQueryable(context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultMessageWithRelationsDto>>(entities);
        }

        [UsePaging]
        [UseFiltering(typeof(MessageFilterType))]
        [UseSorting(typeof(MessageSortType))]
        public async Task<IEnumerable<ResultMessageWithRelationsDto>> GetMessagesByIdsAsync(
            IEnumerable<Guid> keys,
            [Service] IMessageQueryService service,
            [Service] IMessageResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdsQueryable(keys, context);
            var entities = await _queryResolver.ResolveEntitiesAsync(query, resolver, context);
            return _mapper.Map<List<ResultMessageWithRelationsDto>>(entities);
        }

        public async Task<ResultMessageWithRelationsDto> GetMessageByIdAsync(
            Guid key,
            [Service] IMessageQueryService service,
            [Service] IMessageResolver resolver,
            IResolverContext context)
        {
            var query = service.GetByIdQueryable(key, context);
            var entity = await _queryResolver.ResolveEntityAsync(query, resolver, context);
            return _mapper.Map<ResultMessageWithRelationsDto>(entity);
        }
    }


}
