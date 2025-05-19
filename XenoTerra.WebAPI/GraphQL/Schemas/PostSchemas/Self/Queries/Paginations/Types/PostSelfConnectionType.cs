using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Queries.Paginations.Types
{
    public class PostSelfConnectionType : ObjectType<PostSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<PostSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
