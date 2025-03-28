using XenoTerra.BussinessLogicLayer.Services.Entity.StoryService;
using XenoTerra.DTOLayer.Dtos.StoryDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.StoryMutations
{
    public class StoryMutation
    {
        public class ExampleMutation
        {
            public string ReturnStaticString() => "123";
        }

    }
}
