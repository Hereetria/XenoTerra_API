using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Queries.Sorts
{
    public class ViewStoryOwnSortType : SortInputType<ViewStory>
    {
        protected override void Configure(ISortInputTypeDescriptor<ViewStory> descriptor)
        {

        descriptor.Name("ViewStoryOwnSortInput");
        }
    }
}
