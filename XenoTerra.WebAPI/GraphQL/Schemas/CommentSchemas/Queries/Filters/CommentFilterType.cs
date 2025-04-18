using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.CommentQueries.Filters
{
    public class CommentFilterType : FilterInputType<Comment>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Comment> descriptor)
        {
        }
    }
}
