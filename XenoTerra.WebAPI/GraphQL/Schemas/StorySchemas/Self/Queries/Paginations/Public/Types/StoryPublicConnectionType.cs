using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Paginations.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Paginations.Public.Types
{
    public class StoryPublicConnectionType : ObjectType<StoryPublicConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryPublicConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
