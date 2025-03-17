﻿using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.MediaQueryServices
{
    public interface IMediaQueryService : IBaseQueryService<Media, ResultMediaDto, Guid> { }

}
