namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Queries.Paginations.Types
{
    public class StoryHighlightConnectionType : ObjectType<StoryHighlightConnection>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryHighlightConnection> descriptor)
        {
            descriptor.Field(x => x.TotalCount)
                .Type<NonNullType<IntType>>();
        }
    }
}
