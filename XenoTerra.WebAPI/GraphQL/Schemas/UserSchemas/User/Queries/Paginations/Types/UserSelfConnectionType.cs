namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Queries.Paginations.Types
{
    public class UserSelfConnectionType : ObjectType<UserSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
