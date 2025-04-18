namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Queries.Paginations.Types
{
    public class UserSettingConnectionType : ObjectType<UserSettingConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
