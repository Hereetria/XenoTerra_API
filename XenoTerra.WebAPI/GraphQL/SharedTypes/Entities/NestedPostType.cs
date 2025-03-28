using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedPostType : ObjectType<ResultPostDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultPostDto> descriptor)
        {
            descriptor.Field(f => f.PostId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.Caption)
                .Type<StringType>();

            descriptor.Field(f => f.Path)
                .Type<StringType>();

            descriptor.Field(f => f.IsVideo)
                .Type<BooleanType>();

            descriptor.Field(f => f.UserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.CreatedAt)
                .Type<NonNullType<DateTimeType>>();
        }
    }
}
