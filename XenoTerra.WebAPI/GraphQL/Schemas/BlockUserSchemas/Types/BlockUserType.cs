using HotChocolate.Data.Filters;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Types
{
    public class BlockUserType : ObjectType<ResultBlockUserWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultBlockUserWithRelationsDto> descriptor)
        {
            descriptor.Field(f => f.BlockUserId).Type<NonNullType<IdType>>();
            descriptor.Field(f => f.BlockingUserId).Type<NonNullType<IdType>>();
            descriptor.Field(f => f.BlockedUserId).Type<NonNullType<IdType>>();
            descriptor.Field(f => f.BlockedAt).Type<NonNullType<DateTimeType>>();

            descriptor.Field(f => f.BlockingUser)
                .Type<NestedUserType>();

            descriptor.Field(f => f.BlockedUser)
                .Type<NestedUserType>();
        }
    }
}
