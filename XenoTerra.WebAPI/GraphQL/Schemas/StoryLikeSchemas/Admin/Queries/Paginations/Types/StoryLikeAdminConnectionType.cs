using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Queries.Paginations.Types
{
    public class StoryLikeAdminConnectionType : ObjectType<StoryLikeAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryLikeAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
