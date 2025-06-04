using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Queries.Filters
{
    public class CommentLikeSelfFilterType : FilterInputType<CommentLike>
    {
        protected override void Configure(IFilterInputTypeDescriptor<CommentLike> descriptor)
        {
        descriptor.Name("CommentLikeSelfFilterInput");
        }
    }
}
