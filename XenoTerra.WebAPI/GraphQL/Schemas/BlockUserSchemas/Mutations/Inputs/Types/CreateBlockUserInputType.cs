using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Models;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Inputs.Types
{
    public class CreateBlockUserInputType : InputObjectType<CreateBlockUserInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CreateBlockUserInput> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.BlockingUserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.BlockedUserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.BlockedAt)
                .Type<NonNullType<StringType>>();
        }
    }

}
