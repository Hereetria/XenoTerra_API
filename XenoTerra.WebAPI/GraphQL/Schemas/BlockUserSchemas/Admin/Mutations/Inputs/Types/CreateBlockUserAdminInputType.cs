using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Inputs;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Inputs.Types
{
    public class CreateBlockUserAdminInputType : InputObjectType<CreateBlockUserAdminInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CreateBlockUserAdminInput> descriptor)
        {
        }
    }

}
