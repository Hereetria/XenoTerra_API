using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.Entity.ReportCommentService;
using XenoTerra.DTOLayer.Dtos.ReportCommentDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.ReportCommentMutations
{
    public class ReportCommentMutation
    {
        public class ExampleMutation
        {
            public string ReturnStaticString() => "123";
        }

    }
}
