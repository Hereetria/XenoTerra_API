﻿using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Queries.Sorts
{
    public class ReportCommentAdminSortType : SortInputType<ReportComment>
    {
        protected override void Configure(ISortInputTypeDescriptor<ReportComment> descriptor)
        {
        descriptor.Name("ReportCommentAdminSortInput");
        }
    }
}
