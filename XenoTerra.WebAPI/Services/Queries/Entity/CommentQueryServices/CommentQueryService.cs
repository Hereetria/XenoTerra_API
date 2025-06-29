﻿using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.CommentQueryServices
{
    public class CommentQueryService : QueryService<Comment, Guid>, ICommentQueryService
    {
        public CommentQueryService(IReadService<Comment, Guid> readService) : base(readService)
        {
        }
    }

}
