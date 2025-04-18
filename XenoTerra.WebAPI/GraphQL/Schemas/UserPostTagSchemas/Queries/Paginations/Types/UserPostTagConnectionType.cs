namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Queries.Paginations.Types
{
    public class UserPostTagConnectionType : ObjectType<UserPostTagConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
