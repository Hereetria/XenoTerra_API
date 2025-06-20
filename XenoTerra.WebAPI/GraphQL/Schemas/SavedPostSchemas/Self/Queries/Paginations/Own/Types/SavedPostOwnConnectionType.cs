using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Queries.Paginations.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Queries.Paginations.Own.Types
{
    public class SavedPostOwnConnectionType : ObjectType<SavedPostOwnConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<SavedPostOwnConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
