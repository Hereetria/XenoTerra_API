using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Queries.Filters
{
    public class MediaSelfFilterType : FilterInputType<Media>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Media> descriptor)
        {
        descriptor.Name("MediaSelfFilterInput");
        }
    }
}
