using AutoMapper;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.SavedPostResolvers
{
    public class SavedPostResolver : EntityResolver<SavedPost, ResultSavedPostWithRelationsDto, Guid>, ISavedPostResolver
    {
        public SavedPostResolver(EntityDataLoaderFactory entityDataLoaderFactory) : base(entityDataLoaderFactory)
        {
        }
    }
}
