using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Queries.Sorts
{
    public class ViewStoryAdminSortType : SortInputType<ViewStory>
    {
        protected override void Configure(ISortInputTypeDescriptor<ViewStory> descriptor)
        {

        descriptor.Name("ViewStoryAdminSortInput");
        }
    }
}
