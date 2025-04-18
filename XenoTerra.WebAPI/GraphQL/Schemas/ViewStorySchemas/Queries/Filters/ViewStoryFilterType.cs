using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.ViewStoryQueries.Filters
{
    public class ViewStoryFilterType : FilterInputType<ViewStory>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ViewStory> descriptor)
        {
        }
    }
}
