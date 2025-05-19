using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Queries.Filters
{
    public class StoryAdminFilterType : FilterInputType<Story>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Story> descriptor)
        {
        descriptor.Name("StoryAdminFilterInput");
        }
    }
}
