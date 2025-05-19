using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Queries.Paginations.Types
{
    public class UserSettingAdminConnectionType : ObjectType<UserSettingAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
