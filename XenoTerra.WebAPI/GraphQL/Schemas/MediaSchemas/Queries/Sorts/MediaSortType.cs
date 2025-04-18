using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.MediaQueries.Sorts
{
    public class MediaSortType : SortInputType<Media>
    {
        protected override void Configure(ISortInputTypeDescriptor<Media> descriptor)
        {
        }
    }
}
