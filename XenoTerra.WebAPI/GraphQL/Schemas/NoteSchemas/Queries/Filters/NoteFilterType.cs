﻿using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.NoteQueries
{
    public class NoteFilterType : FilterInputType<Note>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Note> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.NoteId);
            descriptor.Field(f => f.Text);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.CreatedAt);

            descriptor.Field(f => f.User)
                .Type<UserNestedFilterType>();
        }
    }
}
