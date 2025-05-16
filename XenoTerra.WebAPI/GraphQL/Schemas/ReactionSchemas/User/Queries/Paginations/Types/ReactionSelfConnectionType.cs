using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Queries.Paginations.Types
{
    public class ReactionSelfConnectionType : ObjectType<ReactionSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
