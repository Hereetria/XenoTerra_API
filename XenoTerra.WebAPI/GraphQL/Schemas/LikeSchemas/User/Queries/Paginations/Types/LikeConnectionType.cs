using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Queries.Paginations.Types
{
    public class LikeConnectionType : ObjectType<LikeConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
