using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.SharedTypes.Filters
{
    public class NoteNestedFilterType : FilterInputType<Note>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Note> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(f => f.NoteId);
            descriptor.Field(f => f.Text);
            descriptor.Field(f => f.UserId);
            descriptor.Field(f => f.CreatedAt);
        }
    }
}
