using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Queries.Paginations.Own.Types
{
    public class UserSettingOwnConnectionType : ObjectType<UserSettingOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
