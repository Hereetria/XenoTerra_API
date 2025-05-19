using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Filters
{
    public class FollowSelfFilterType : FilterInputType<Follow>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Follow> descriptor)
        {
        descriptor.Name("FollowSelfFilterInput");
        }
    }
}
