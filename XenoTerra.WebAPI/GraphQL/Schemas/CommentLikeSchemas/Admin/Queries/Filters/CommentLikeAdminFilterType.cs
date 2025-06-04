using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Queries.Filters
{
    public class CommentLikeAdminFilterType : FilterInputType<CommentLike>
    {
        protected override void Configure(IFilterInputTypeDescriptor<CommentLike> descriptor)
        {
        descriptor.Name("CommentLikeAdminFilterInput");
        }
    }
}
