using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Models;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Inputs.Types
{
    public class CreateBlockUserInputType : InputObjectType<CreateBlockUserInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CreateBlockUserInput> descriptor)
        {
        }
    }

}
