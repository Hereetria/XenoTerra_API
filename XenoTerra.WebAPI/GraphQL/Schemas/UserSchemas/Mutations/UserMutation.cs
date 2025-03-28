using XenoTerra.BussinessLogicLayer.Services.Entity.UserService;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.UserMutations
{
    public class UserMutation
    {
        public class ExampleMutation
        {
            public string ReturnStaticString() => "123";
        }

    }
}
