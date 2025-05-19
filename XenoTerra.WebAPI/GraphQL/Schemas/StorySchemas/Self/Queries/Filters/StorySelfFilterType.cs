using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Filters
{
    public class StorySelfFilterType : FilterInputType<Story>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Story> descriptor)
        {
        descriptor.Name("StorySelfFilterInput");
        }
    }
}
