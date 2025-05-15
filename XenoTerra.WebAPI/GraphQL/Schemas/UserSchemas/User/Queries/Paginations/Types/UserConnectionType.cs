namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Queries.Paginations.Types
{
    public class UserConnectionType : ObjectType<UserConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<UserConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
