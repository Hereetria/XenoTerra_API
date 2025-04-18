namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Queries.Paginations.Types
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
