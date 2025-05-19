namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Queries.Paginations.Types
{
    public class UserSettingSelfConnectionType : ObjectType<UserSettingSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
