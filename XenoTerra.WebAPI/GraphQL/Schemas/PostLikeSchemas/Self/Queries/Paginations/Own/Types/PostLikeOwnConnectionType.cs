using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Queries.Paginations.Own.Types
{
    public class PostLikeOwnConnectionType : ObjectType<PostLikeOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<PostLikeOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
