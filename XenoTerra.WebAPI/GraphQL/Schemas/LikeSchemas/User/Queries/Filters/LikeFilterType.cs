using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Queries.Filters
{
    public class LikeFilterType : FilterInputType<Like>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Like> descriptor)
        {
        }
    }
}
