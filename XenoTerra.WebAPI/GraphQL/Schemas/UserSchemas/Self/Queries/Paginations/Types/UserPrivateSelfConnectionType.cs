namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Queries.Paginations.Types
{
    public class UserPrivateSelfConnectionType : ObjectType<UserPrivateSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPrivateSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
