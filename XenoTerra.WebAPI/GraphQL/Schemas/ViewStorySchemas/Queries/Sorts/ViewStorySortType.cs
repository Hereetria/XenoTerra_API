using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.ViewStoryQueries.Sorts
{
    public class ViewStorySortType : SortInputType<ViewStory>
    {
        protected override void Configure(ISortInputTypeDescriptor<ViewStory> descriptor)
        {

        }
    }
}
