using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Queries.Sorts
{
    public class HighlightOwnSortType : SortInputType<Highlight>
    {
        protected override void Configure(ISortInputTypeDescriptor<Highlight> descriptor)
        {
        descriptor.Name("HighlightOwnSortInput");
        }
    }
}
