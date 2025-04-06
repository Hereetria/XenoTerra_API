using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.Entity.MessageService;
using XenoTerra.DTOLayer.Dtos.MessageDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.MessageMutations
{
    public class MessageMutation
    {
        public string ReturnStaticString() => "123";
    }
}
