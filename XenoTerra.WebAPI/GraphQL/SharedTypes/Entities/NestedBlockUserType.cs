using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedBlockUserType : ObjectType<ResultBlockUserDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultBlockUserDto> descriptor)
        {
            descriptor.Field(f => f.BlockUserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.BlockingUserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.BlockedUserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.BlockedAt)
                .Type<NonNullType<DateTimeType>>();
        }
    }
}
