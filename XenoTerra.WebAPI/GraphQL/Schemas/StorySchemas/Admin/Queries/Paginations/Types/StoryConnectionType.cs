using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Queries.Paginations.Types
{
    public class StoryConnectionType : ObjectType<StoryConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
