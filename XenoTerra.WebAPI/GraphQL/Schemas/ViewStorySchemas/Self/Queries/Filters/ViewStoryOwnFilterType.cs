using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Queries.Filters
{
    public class ViewStoryOwnFilterType : FilterInputType<ViewStory>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ViewStory> descriptor)
        {
        descriptor.Name("ViewStoryOwnFilterInput");
        }
    }
}
