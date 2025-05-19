using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries.Paginations;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries.Paginations.Types
{
    public class NoteSelfConnectionType : ObjectType<NoteSelfConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<NoteSelfConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
