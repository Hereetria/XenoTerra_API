using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;

namespace XenoTerra.WebAPI.GraphQL.Resolvers.Entity.NoteResolvers
{
    public interface INoteResolver : IEntityResolver<Note, Guid>
    {
    }

}
