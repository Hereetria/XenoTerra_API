using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Queries.Paginations.Types
{
    public class ReactionAdminConnectionType : ObjectType<ReactionAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
