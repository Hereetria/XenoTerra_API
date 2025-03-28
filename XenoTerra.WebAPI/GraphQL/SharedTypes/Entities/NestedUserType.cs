using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedUserType : ObjectType<ResultUserDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserDto> descriptor)
        {
            descriptor.Field(f => f.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.FullName)
                .Type<StringType>();

            descriptor.Field(f => f.Bio)
                .Type<StringType>();

            descriptor.Field(f => f.ProfilePicture)
                .Type<StringType>();

            descriptor.Field(f => f.Website)
                .Type<StringType>();

            descriptor.Field(f => f.BirthDate)
                .Type<NonNullType<DateTimeType>>();

            descriptor.Field(f => f.FollowersCount)
                .Type<NonNullType<IntType>>();

            descriptor.Field(f => f.FollowingCount)
                .Type<NonNullType<IntType>>();

            descriptor.Field(f => f.IsVerified)
                .Type<NonNullType<BooleanType>>();

            descriptor.Field(f => f.LastActive)
                .Type<NonNullType<DateTimeType>>();
        }
    }
}
