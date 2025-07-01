using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Filters
{
    public class PostOwnFilterType : FilterInputType<Post>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Post> descriptor)
        {
        descriptor.Name("PostOwnFilterInput");
        }
    }
}
