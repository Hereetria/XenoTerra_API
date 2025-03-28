using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.Entity.MessageService;
using XenoTerra.DTOLayer.Dtos.MessageDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.MessageMutations
{
    public class MessageMutation
    {
        public class ExampleMutation
        {
            public string ReturnStaticString() => "123";
        }
    }
}
