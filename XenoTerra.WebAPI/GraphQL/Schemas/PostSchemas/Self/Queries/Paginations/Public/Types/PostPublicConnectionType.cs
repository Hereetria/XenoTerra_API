using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Paginations.Public;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Paginations.Public.Types
{
    public class PostPublicConnectionType : ObjectType<PostPublicConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<PostPublicConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
