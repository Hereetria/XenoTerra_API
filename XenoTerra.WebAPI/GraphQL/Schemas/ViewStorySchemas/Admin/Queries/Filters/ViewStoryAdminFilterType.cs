using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Queries.Filters
{
    public class ViewStoryAdminFilterType : FilterInputType<ViewStory>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ViewStory> descriptor)
        {
        descriptor.Name("ViewStoryAdminFilterInput");
        }
    }
}
