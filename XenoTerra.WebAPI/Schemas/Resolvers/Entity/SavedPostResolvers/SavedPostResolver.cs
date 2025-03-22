using AutoMapper;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.SavedPostResolvers
{
    public class SavedPostResolver : EntityResolver<SavedPost, ResultSavedPostWithRelationsDto, Guid>, ISavedPostResolver
    {
        public SavedPostResolver(IEntityFieldMapBuilder<SavedPost, ResultSavedPostWithRelationsDto, Guid> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : base(entityFieldMapBuilder, dataLoaderInvoker)
        {
        }
    }
}
