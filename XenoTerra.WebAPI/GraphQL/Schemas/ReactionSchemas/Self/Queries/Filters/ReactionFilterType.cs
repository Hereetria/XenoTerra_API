﻿using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Queries.Filters;

public class ReactionFilterType : FilterInputType<Reaction>
{
    protected override void Configure(IFilterInputTypeDescriptor<Reaction> descriptor)
    {
    descriptor.Name("ReactionFilterInput");
    }
}
