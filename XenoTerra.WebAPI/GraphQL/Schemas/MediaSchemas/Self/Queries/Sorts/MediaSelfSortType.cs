using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Queries.Sorts
{
    public class MediaSelfSortType : SortInputType<Media>
    {
        protected override void Configure(ISortInputTypeDescriptor<Media> descriptor)
        {
        descriptor.Name("MediaSelfSortInput");
        }
    }
}
