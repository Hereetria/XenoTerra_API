using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts
{
    public class NoteNestedSortType : SortInputType<Note>
    {
        protected override void Configure(ISortInputTypeDescriptor<Note> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.NoteId);
            descriptor.Field(f => f.Text);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.CreatedAt);
        }
    }
}
