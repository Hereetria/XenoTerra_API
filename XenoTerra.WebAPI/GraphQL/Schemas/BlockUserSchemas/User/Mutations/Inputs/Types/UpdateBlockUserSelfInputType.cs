using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Inputs.Types
{
    public class UpdateBlockUserSelfInputType : InputObjectType<UpdateBlockUserSelfInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<UpdateBlockUserSelfInput> descriptor)
        {
        }
    }
}
