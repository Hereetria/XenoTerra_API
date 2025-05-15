using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Inputs.Types
{
    public class CreateBlockUserInputType : InputObjectType<CreateBlockUserInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CreateBlockUserInput> descriptor)
        {
        }
    }

}
