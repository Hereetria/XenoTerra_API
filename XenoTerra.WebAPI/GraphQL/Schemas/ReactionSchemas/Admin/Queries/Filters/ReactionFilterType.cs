using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Queries.Filters;

public class ReactionFilterType : FilterInputType<Reaction>
{
    protected override void Configure(IFilterInputTypeDescriptor<Reaction> descriptor)
    {
    }
}
