using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.PostQueries.Filters
{
    public class PostFilterType : FilterInputType<Post>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Post> descriptor)
        {
        }
    }
}
