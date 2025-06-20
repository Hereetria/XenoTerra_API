using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Queries.Filters
{
    public class StoryLikeFilterType : FilterInputType<StoryLike>
    {
        protected override void Configure(IFilterInputTypeDescriptor<StoryLike> descriptor)
        {
        descriptor.Name("StoryLikeFilterInput");
        }
    }
}
