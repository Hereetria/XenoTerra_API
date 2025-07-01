using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Queries.Sorts
{
    public class SavedPostOwnSortType : SortInputType<SavedPost>
    {
        protected override void Configure(ISortInputTypeDescriptor<SavedPost> descriptor)
        {
        descriptor.Name("SavedPostOwnSortInput");
        }
    }
}
