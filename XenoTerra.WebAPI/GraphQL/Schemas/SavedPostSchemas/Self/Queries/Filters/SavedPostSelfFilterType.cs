using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Queries.Filters
{
    public class SavedPostSelfFilterType : FilterInputType<SavedPost>
    {
        protected override void Configure(IFilterInputTypeDescriptor<SavedPost> descriptor)
        {
        descriptor.Name("SavedPostSelfFilterInput");
        }
    }
}
