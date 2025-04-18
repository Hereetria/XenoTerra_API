using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.ReactionQueries.Filters
{
    public class ReactionFilterType : FilterInputType<Reaction>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Reaction> descriptor)
        {
        }
    }
}
