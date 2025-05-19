using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Queries.Sorts
{
    public class StoryAdminSortType : SortInputType<Story>
    {
        protected override void Configure(ISortInputTypeDescriptor<Story> descriptor)
        {
        descriptor.Name("StoryAdminSortInput");
        }
    }
}
