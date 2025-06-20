using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Queries.Paginations.Own.Types
{
    public class StoryLikeOwnConnectionType : ObjectType<StoryLikeOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryLikeOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
