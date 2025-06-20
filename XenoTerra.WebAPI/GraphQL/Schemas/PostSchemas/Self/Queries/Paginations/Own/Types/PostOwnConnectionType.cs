using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Paginations.Own.Types
{
    public class PostOwnConnectionType : ObjectType<PostOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<PostOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
