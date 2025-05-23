﻿using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Queries.Filters
{
    public class StoryHighlightAdminFilterType : FilterInputType<StoryHighlight>
    {
        protected override void Configure(IFilterInputTypeDescriptor<StoryHighlight> descriptor)
        {
        descriptor.Name("StoryHighlightAdminFilterInput");
        }
    }
}
