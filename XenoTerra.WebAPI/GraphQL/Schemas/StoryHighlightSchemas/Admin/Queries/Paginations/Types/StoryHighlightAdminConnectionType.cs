using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Queries.Paginations.Types
{
    public class StoryHighlightAdminConnectionType : ObjectType<StoryHighlightAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryHighlightAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
