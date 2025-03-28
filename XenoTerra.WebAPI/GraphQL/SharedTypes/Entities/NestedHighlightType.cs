using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedHighlightType : ObjectType<ResultHighlightDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultHighlightDto> descriptor)
        {
            descriptor.Field(f => f.HighlightId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.Name)
                .Type<StringType>();

            descriptor.Field(f => f.ProfilePicturePath)
                .Type<StringType>();
        }
    }
}
