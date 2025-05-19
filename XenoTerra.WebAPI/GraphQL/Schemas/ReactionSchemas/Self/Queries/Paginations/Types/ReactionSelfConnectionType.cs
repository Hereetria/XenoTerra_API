using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Queries.Paginations.Types
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
