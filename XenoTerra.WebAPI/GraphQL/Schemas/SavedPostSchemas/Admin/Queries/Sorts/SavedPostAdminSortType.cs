using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Queries.Sorts
{
    public class SavedPostAdminSortType : SortInputType<SavedPost>
    {
        protected override void Configure(ISortInputTypeDescriptor<SavedPost> descriptor)
        {
        descriptor.Name("SavedPostAdminSortInput");
        }
    }
}
