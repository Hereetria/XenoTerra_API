﻿using AutoMapper;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ViewStoryResolvers
{
    public class ViewStoryResolver : EntityResolver<ViewStory, ResultViewStoryWithRelationsDto, Guid>, IViewStoryResolver
    {
        public ViewStoryResolver(IEntityFieldMapBuilder<ViewStory, ResultViewStoryWithRelationsDto, Guid> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : base(entityFieldMapBuilder, dataLoaderInvoker)
        {
        }
    }
}
 