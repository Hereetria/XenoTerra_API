using AutoMapper;
using HotChocolate;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.MessageService;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.MessageQueries
{
    public class MessageQuery
    {
        public async Task<IEnumerable<ResultMessageWithRelationsDto>> GetAllMessagesAsync(
            [Service] IMessageReadService messageReadService,
            [Service] MessageResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = messageReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<Message>().AsQueryable();

            var messages = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(messages, context);

            return mapper.Map<List<ResultMessageWithRelationsDto>>(messages);
        }

        public async Task<IEnumerable<ResultMessageWithRelationsDto>> GetMessagesByIdsAsync(
            [Service] IMessageReadService messageReadService,
            [Service] MessageResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = messageReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<Message>().AsQueryable();

            var messages = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(messages, context);

            return mapper.Map<List<ResultMessageWithRelationsDto>>(messages);
        }

        public async Task<ResultMessageWithRelationsDto> GetMessageByIdAsync(
            [Service] IMessageReadService messageReadService,
            [Service] MessageResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = messageReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<Message>().AsQueryable();

            var message = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"Message with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(message, context);

            return mapper.Map<ResultMessageWithRelationsDto>(message);
        }

    }
}
