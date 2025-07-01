using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries.Sorts
{
    public class NotePublicSortType : SortInputType<Note>
    {
        protected override void Configure(ISortInputTypeDescriptor<Note> descriptor)
        {
        descriptor.Name("NotePublicSortInput");
        }
    }
}
