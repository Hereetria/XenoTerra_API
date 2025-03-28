using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.ReactionQueries.Filters
{
    public class ReactionFilterType : FilterInputType<Reaction>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Reaction> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.ReactionId);
            descriptor.Field(f => f.Payload);
            descriptor.Field(f => f.MessageId);
            descriptor.Field(f => f.UserId);

            descriptor.Field(f => f.Message)
                .Type<MessageNestedFilterType>();

            descriptor.Field(f => f.User)
                .Type<UserNestedFilterType>();
        }
    }
}
