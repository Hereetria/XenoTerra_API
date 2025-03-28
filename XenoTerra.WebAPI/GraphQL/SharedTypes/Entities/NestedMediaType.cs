using XenoTerra.DTOLayer.Dtos.MediaDtos;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Entities
{
    public class NestedMediaType : ObjectType<ResultMediaDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultMediaDto> descriptor)
        {
            descriptor.Field(f => f.MediaId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.PhotoUrl)
                .Type<StringType>();

            descriptor.Field(f => f.UserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(f => f.UploadedAt)
                .Type<NonNullType<DateTimeType>>();
        }
    }
}
