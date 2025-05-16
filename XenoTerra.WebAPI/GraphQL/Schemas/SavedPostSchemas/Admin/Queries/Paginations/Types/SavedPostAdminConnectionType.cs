using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Queries.Paginations.Types
{
    public class SavedPostAdminConnectionType : ObjectType<SavedPostAdminConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostAdminConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
