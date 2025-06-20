using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Queries.Paginations.Own.Types
{
    public class ReactionOwnConnectionType : ObjectType<ReactionOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
