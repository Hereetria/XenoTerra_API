using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Queries.Paginations.Types
{
    public class StoryHighlightConnectionType : ObjectType<StoryHighlightConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryHighlightConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
