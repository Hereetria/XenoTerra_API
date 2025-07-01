using HotChocolate.Data.Filters;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Queries.Filters
{
    public class NotePublicFilterType : FilterInputType<Note>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Note> descriptor)
        {
        descriptor.Name("NotePublicFilterInput");
        }
    }
}
