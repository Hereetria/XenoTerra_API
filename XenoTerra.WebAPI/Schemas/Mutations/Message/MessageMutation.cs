using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.MessageServices;
using XenoTerra.DTOLayer.Dtos.MessageDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.Message
{
    public class MessageMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Message")]
        public async Task<ResultMessageByIdDto> CreateMessageAsync(CreateMessageDto createMessageDto, [Service] IMessageServiceBLL messageServiceBLL)
        {
            var result = await messageServiceBLL.CreateAsync(createMessageDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Message")]
        public async Task<ResultMessageByIdDto> UpdateMessageAsync(UpdateMessageDto updateMessageDto, [Service] IMessageServiceBLL messageServiceBLL)
        {
            var result = await messageServiceBLL.UpdateAsync(updateMessageDto);
            return result;
        }

        [GraphQLDescription("Delete a Message by ID")]
        public async Task<bool> DeleteMessageAsync(Guid id, [Service] IMessageServiceBLL messageServiceBLL)
        {
            var result = await messageServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
