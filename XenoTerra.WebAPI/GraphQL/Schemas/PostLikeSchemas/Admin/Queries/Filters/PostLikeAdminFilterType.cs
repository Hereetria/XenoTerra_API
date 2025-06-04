using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Queries.Filters
{
    public class PostLikeAdminFilterType : FilterInputType<PostLike>
    {
        protected override void Configure(IFilterInputTypeDescriptor<PostLike> descriptor)
        {
        descriptor.Name("PostLikeAdminFilterInput");
        }
    }
}
