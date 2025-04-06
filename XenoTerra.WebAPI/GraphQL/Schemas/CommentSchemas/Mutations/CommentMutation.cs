using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService;
using XenoTerra.BussinessLogicLayer.Services.Entity.CommentService;
using XenoTerra.DTOLayer.Dtos.CommentDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.CommentMutations
{
    public class CommentMutation
    {
        public string ReturnStaticString() => "123";
    }
}
