using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.SavedPostQueries.Filters
{
    public class SavedPostFilterType : FilterInputType<SavedPost>
    {
        protected override void Configure(IFilterInputTypeDescriptor<SavedPost> descriptor)
        {
        }
    }
}
