using XenoTerra.DTOLayer.Dtos.BlockUserDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Types
{
    public class BlockUserType : ObjectType<ResultBlockUserDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultBlockUserDto> descriptor)
        {
            descriptor.Name("BlockUsera");

            descriptor.Field(f => f.BlockUserId).Type<NonNullType<IdType>>();
            descriptor.Field(f => f.BlockingUserId).Type<NonNullType<IdType>>();
            descriptor.Field(f => f.BlockedUserId).Type<NonNullType<IdType>>();
            descriptor.Field(f => f.BlockedAt).Type<NonNullType<DateTimeType>>();
        }
    }
}
