using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Inputs
{
    public class UpdateBlockUserInputType : InputObjectType<UpdateBlockUserDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<UpdateBlockUserDto> descriptor)
        {
            descriptor.Field(x => x.BlockUserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(x => x.BlockingUserId)
                .Type<IdType>();

            descriptor.Field(x => x.BlockedUserId)
                .Type<IdType>();

            descriptor.Field(x => x.BlockedAt)
                .Type<DateTimeType>();
        }
    }
}
