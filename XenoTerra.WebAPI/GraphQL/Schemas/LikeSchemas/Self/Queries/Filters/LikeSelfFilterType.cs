using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Queries.Filters
{
    public class LikeSelfFilterType : FilterInputType<Like>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Like> descriptor)
        {
        descriptor.Name("LikeSelfFilterInput");
        }
    }
}
