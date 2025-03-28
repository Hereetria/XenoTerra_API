using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.Entity.HighlightService;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.HighlightMutations
{
    public class HighlightMutation
    {
        public class ExampleMutation
        {
            public string ReturnStaticString() => "123";
        }

    }
}
