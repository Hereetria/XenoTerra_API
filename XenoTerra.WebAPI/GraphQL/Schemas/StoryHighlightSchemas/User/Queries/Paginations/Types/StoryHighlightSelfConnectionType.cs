using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Queries.Paginations.Types
{
    public class StoryHighlightSelfConnectionType : ObjectType<StoryHighlightSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryHighlightSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
