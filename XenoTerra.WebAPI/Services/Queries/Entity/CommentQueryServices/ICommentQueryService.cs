﻿using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.CommentQueryServices
{
    public interface ICommentQueryService : IBaseQueryService<Comment, ResultCommentDto, Guid> { }
}
