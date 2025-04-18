using HotChocolate.Data.Sorting;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Sorts;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.NoteQueries.Sorts
{
    public class NoteSortType : SortInputType<Note>
    {
        protected override void Configure(ISortInputTypeDescriptor<Note> descriptor)
        {
        }
    }
}
