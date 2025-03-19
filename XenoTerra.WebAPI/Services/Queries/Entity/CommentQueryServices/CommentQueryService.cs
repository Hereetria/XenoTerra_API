using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.CommentDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.CommentQueryServices
{
    public class CommentQueryService : QueryService<Comment, ResultCommentWithRelationsDto, Guid>, ICommentQueryService
    {
        public CommentQueryService(IReadService<Comment, ResultCommentWithRelationsDto, Guid> readService, IMapper mapper) : base(readService, mapper)
        {
        }
    }

}
