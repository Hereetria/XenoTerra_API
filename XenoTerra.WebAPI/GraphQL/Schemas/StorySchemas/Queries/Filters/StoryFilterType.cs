using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.StoryQueries.Filters
{
    public class StoryFilterType : FilterInputType<Story>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Story> descriptor)
        {
        }
    }
}
