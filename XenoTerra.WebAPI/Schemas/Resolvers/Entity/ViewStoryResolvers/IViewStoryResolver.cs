﻿using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ViewStoryResolvers
{
    public interface IViewStoryResolver : IEntityResolver<ViewStory, ResultViewStoryWithRelationsDto, Guid>
    {
    }
}
