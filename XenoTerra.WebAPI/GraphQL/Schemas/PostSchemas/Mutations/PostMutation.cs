using XenoTerra.BussinessLogicLayer.Services.Entity.PostService;
using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.PostMutations
{
    public class PostMutation
    {
        public class ExampleMutation
        {
            public string ReturnStaticString() => "123";
        }

    }
}
