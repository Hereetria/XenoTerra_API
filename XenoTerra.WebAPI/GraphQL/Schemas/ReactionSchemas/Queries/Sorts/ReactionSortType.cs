using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.ReactionQueries
{
    public class ReactionSortType : SortInputType<Reaction>
    {
        protected override void Configure(ISortInputTypeDescriptor<Reaction> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.ReactionId);
            descriptor.Field(f => f.Payload);
            descriptor.Field(f => f.MessageId);
            descriptor.Field(f => f.UserId);

            descriptor.Field(f => f.Message)
                .Type<MessageNestedSortType>();

            descriptor.Field(f => f.User)
                .Type<UserNestedSortType>();
        }
    }
}
