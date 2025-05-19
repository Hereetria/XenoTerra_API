using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Queries.Filters;

public class ReactionAdminFilterType : FilterInputType<Reaction>
{
    protected override void Configure(IFilterInputTypeDescriptor<Reaction> descriptor)
    {
    descriptor.Name("ReactionAdminFilterInput");
    }
}
