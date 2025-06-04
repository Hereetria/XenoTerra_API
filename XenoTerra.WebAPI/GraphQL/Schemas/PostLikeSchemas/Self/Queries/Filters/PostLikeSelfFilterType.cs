using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Filters
{
    public class PostLikeSelfFilterType : FilterInputType<PostLike>
    {
        protected override void Configure(IFilterInputTypeDescriptor<PostLike> descriptor)
        {
        descriptor.Name("PostLikeSelfFilterInput");
        }
    }
}
