using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Queries.Paginations.Own.Types
{
    public class StoryOwnConnectionType : ObjectType<StoryOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
