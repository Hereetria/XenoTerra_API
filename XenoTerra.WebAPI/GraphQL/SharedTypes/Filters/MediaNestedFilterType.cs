using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class MediaNestedFilterType : FilterInputType<Media>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Media> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.MediaId);
            descriptor.Field(f => f.PhotoUrl);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.UploadedAt);
        }
    }
}
