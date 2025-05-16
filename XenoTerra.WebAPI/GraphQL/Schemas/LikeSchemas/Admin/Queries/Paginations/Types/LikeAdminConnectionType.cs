using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Queries.Paginations.Types
{
    public class LikeAdminConnectionType : ObjectType<LikeAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<LikeAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
