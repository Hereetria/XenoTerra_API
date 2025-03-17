using AutoMapper;
using HotChocolate;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.MessageService;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.MessageResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.MessageQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.MessageQueries
{
    public class MessageQuery
    {
        private readonly IMapper _mapper;

        public MessageQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultMessageWithRelationsDto>> GetAllMessagesAsync(
            [Service] IMessageQueryService service,
            [Service] IMessageResolver resolver,
            IResolverContext context)
        {
            var messages = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(messages, context);
            var messageDtos = _mapper.Map<List<ResultMessageWithRelationsDto>>(messages);
            return messageDtos;
        }

        public async Task<IEnumerable<ResultMessageWithRelationsDto>> GetMessagesByIdsAsync(
            [Service] IMessageQueryService service,
            [Service] IMessageResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var messages = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(messages, context);
            var messageDtos = _mapper.Map<List<ResultMessageWithRelationsDto>>(messages);
            return messageDtos;
        }

        public async Task<ResultMessageWithRelationsDto> GetMessageByIdAsync(
            [Service] IMessageQueryService service,
            [Service] IMessageResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var message = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(message, context);
            var messageDto = _mapper.Map<ResultMessageWithRelationsDto>(message);
            return messageDto;
        }
    }

}
