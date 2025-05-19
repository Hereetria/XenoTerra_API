using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Queries.Sorts
{
    public class MediaAdminSortType : SortInputType<Media>
    {
        protected override void Configure(ISortInputTypeDescriptor<Media> descriptor)
        {
        descriptor.Name("MediaAdminSortInput");
        }
    }
}
