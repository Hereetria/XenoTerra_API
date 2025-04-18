using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Filters;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.NoteQueries
{
    public class NoteFilterType : FilterInputType<Note>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Note> descriptor)
        {
        }
    }
}
