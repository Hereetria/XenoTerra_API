using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.NoteQueries.Sorts
{
    public class NoteSortType : SortInputType<Note>
    {
        protected override void Configure(ISortInputTypeDescriptor<Note> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.NoteId);
            descriptor.Field(f => f.Text);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.CreatedAt);

            descriptor.Field(f => f.User)
                .Type<UserNestedSortType>();
        }
    }
}
