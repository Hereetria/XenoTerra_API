using AutoMapper;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ViewStoryResolvers
{
    public class ViewStoryResolver : EntityResolver<ViewStory, ResultViewStoryWithRelationsDto, Guid>, IViewStoryResolver
    {
        public ViewStoryResolver(EntityDataLoaderFactory entityDataLoaderFactory) : base(entityDataLoaderFactory)
        {
        }
    }
}
