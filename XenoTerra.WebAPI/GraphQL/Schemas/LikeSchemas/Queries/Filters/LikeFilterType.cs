using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.LikeQueries.Filters
{
    public class LikeFilterType : FilterInputType<Like>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Like> descriptor)
        {
        }
    }
}
