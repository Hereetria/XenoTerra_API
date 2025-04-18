using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.FollowQueries.Filters
{
    public class FollowFilterType : FilterInputType<Follow>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Follow> descriptor)
        {
        }
    }
}
