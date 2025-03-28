using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedUserPostTagType : ObjectType<ResultUserPostTagDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultUserPostTagDto> descriptor)
        {
            descriptor.Field(f => f.PostId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.UserId)
                .Type<NonNullType<IdType>>();
        }
    }
}
