using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class ReactionNestedFilterType : FilterInputType<Reaction>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Reaction> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.ReactionId);
            descriptor.Field(f => f.Payload);
            descriptor.Field(f => f.MessageId);
            descriptor.Field(f => f.UserId);
        }
    }
}
