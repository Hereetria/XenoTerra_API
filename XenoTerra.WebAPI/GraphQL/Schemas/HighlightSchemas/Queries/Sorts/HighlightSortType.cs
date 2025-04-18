using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.HighlightQueries.Sorts
{
    public class HighlightSortType : SortInputType<Highlight>
    {
        protected override void Configure(ISortInputTypeDescriptor<Highlight> descriptor)
        {
        }
    }
}
