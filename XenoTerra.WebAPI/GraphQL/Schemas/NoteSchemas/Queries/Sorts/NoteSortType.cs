﻿using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Queries.Sorts
{
    public class NoteSortType : SortInputType<Note>
    {
        protected override void Configure(ISortInputTypeDescriptor<Note> descriptor)
        {
        }
    }
}
