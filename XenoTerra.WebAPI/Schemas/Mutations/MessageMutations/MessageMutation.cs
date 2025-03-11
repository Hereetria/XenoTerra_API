using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.Entity.MessageService;
using XenoTerra.DTOLayer.Dtos.MessageDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.MessageMutations
{
    public class MessageMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Message")]
        public async Task<ResultMessageDto> CreateMessageAsync(CreateMessageDto createMessageDto, [Service] IMessageWriteService messageWriteService)
        {
            var result = await messageWriteService.CreateAsync(createMessageDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Message")]
        public async Task<ResultMessageDto> UpdateMessageAsync(UpdateMessageDto updateMessageDto, [Service] IMessageWriteService messageWriteService)
        {
            var result = await messageWriteService.UpdateAsync(updateMessageDto);
            return result;
        }

        [GraphQLDescription("Delete a Message by ID")]
        public async Task<bool> DeleteMessageAsync(Guid id, [Service] IMessageWriteService messageWriteService)
        {
            var result = await messageWriteService.DeleteAsync(id);
            return result;
        }
    }
}
