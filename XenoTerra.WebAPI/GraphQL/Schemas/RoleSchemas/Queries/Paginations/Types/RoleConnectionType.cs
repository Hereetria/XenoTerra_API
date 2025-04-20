namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Queries.Paginations.Types
{
    public class RoleConnectionType : ObjectType<RoleConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
