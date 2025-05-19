using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Queries.Filters
{
    public class SavedPostAdminFilterType : FilterInputType<SavedPost>
    {
        protected override void Configure(IFilterInputTypeDescriptor<SavedPost> descriptor)
        {
        descriptor.Name("SavedPostAdminFilterInput");
        }
    }
}
