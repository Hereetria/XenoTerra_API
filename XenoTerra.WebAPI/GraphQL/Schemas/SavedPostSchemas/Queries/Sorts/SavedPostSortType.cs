using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.SavedPostQueries.Sorts
{
    public class SavedPostSortType : SortInputType<SavedPost>
    {
        protected override void Configure(ISortInputTypeDescriptor<SavedPost> descriptor)
        {
        }
    }
}
