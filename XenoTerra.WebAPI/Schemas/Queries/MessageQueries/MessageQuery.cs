using HotChocolate;
using XenoTerra.DTOLayer.Dtos.MessageDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.MessageQueries
{
    public class MessageQuery
    {
        public string GetRandomData()
        {
            return "Default data to prevent query class from being empty.";
        }

        //[UseProjection]
        //[GraphQLDescription("Get all Messages")]
        //public IQueryable<ResultMessageDto> GetAllMessages([Service] IMessageServiceBLL messageServiceBLL)
        //{
        //    return messageServiceBLL.GetAllQuerable();
        //}

        //[UseProjection]
        //[GraphQLDescription("Get Message by ID")]
        //public IQueryable<ResultMessageByIdDto> GetMessageById(Guid id, [Service] IMessageServiceBLL messageServiceBLL)
        //{
        //    var result = messageServiceBLL.GetByIdQuerable(id);
        //    if (result == null)
        //    {
        //        throw new Exception($"Message with ID {id} not found");
        //    }
        //    return result;
        //}
    }
}
