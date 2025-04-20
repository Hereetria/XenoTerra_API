using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Queries.Sorts
{
    public class SavedPostSortType : SortInputType<SavedPost>
    {
        protected override void Configure(ISortInputTypeDescriptor<SavedPost> descriptor)
        {
        }
    }
}
