using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Queries.Paginations.Types
{
    public class ReactionConnectionType : ObjectType<ReactionConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<ReactionConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
