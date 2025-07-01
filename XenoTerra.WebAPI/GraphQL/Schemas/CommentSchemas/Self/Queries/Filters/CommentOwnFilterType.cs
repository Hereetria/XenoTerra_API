using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Queries.Filters
{
    public class CommentOwnFilterType : FilterInputType<Comment>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Comment> descriptor)
        {
        descriptor.Name("CommentOwnFilterInput");
        }
    }
}
