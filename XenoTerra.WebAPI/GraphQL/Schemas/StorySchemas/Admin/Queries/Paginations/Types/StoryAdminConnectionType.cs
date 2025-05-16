using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Queries.Paginations.Types
{
    public class StoryAdminConnectionType : ObjectType<StoryAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
