using XenoTerra.DTOLayer.Dtos.SavedPostDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedSavedPostType : ObjectType<ResultSavedPostDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultSavedPostDto> descriptor)
        {
            descriptor.Field(f => f.SavedPostId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.UserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.PostId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.SavedAt)
                .Type<NonNullType<DateTimeType>>();
        }
    }
}
