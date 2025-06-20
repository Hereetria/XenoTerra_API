using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Queries.Filters
{
    public class StoryLikeAdminFilterType : FilterInputType<StoryLike>
    {
        protected override void Configure(IFilterInputTypeDescriptor<StoryLike> descriptor)
        {
        descriptor.Name("StoryLikeAdminFilterInput");
        }
    }
}
