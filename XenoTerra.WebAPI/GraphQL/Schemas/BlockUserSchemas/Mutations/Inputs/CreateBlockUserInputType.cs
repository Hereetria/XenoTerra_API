using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Inputs
{
    public class CreateBlockUserInputType : InputObjectType<CreateBlockUserDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<CreateBlockUserDto> descriptor)
        {
            descriptor.Field(x => x.BlockingUserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(x => x.BlockedUserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(x => x.BlockedAt)
                .Type<NonNullType<DateTimeType>>();
        }
    }
}
