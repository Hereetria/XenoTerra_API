using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Models;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Inputs.Types
{
    public class UpdateBlockUserInputType : InputObjectType<UpdateBlockUserInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<UpdateBlockUserInput> descriptor)
        {
            descriptor.Field(x => x.BlockUserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(x => x.BlockingUserId)
                .Type<IdType>();

            descriptor.Field(x => x.BlockedUserId)
                .Type<IdType>();

            descriptor.Field(x => x.BlockedAt)
                .Type<StringType>();
        }
    }
}
