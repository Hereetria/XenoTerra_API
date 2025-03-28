using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.MediaQueries.Filters
{
    public class MediaFilterType : FilterInputType<Media>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Media> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.MediaId);
            descriptor.Field(f => f.PhotoUrl);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.UploadedAt);

            descriptor.Field(f => f.User)
                .Type<UserNestedFilterType>();
        }
    }
}
