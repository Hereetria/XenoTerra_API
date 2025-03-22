using AutoMapper;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.NoteResolvers
{
    public class NoteResolver : EntityResolver<Note, ResultNoteWithRelationsDto, Guid>, INoteResolver
    {
        public NoteResolver(IEntityFieldMapBuilder<Note, ResultNoteWithRelationsDto, Guid> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : base(entityFieldMapBuilder, dataLoaderInvoker)
        {
        }
    }
}
