using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts
{
    public class ReactionNestedSortType : SortInputType<Reaction>
    {
        protected override void Configure(ISortInputTypeDescriptor<Reaction> descriptor)
        {
            descriptor.Name("ReactionNestedSortInput");
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.ReactionId);
            descriptor.Field(f => f.Payload);
            descriptor.Field(f => f.MessageId);
            descriptor.Field(f => f.UserId);
        }
    }
}
