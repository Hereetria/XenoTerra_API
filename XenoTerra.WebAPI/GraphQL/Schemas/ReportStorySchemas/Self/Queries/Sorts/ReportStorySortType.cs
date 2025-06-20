﻿using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Queries.Sorts
{
    public class ReportStorySortType : SortInputType<ReportStory>
    {
        protected override void Configure(ISortInputTypeDescriptor<ReportStory> descriptor)
        {
        descriptor.Name("ReportStorySortInput");
        }
    }
}
