namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Queries.Paginations.Types
{
    public class FollowSelfConnectionType : ObjectType<FollowSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<FollowSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
