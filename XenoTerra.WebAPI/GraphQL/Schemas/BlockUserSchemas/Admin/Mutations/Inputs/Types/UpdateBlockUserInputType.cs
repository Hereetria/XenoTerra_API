using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Inputs.Types
{
    public class UpdateBlockUserInputType : InputObjectType<UpdateBlockUserInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<UpdateBlockUserInput> descriptor)
        {
        }
    }
}
