using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.PostQueryServices
{
    public class PostQueryService : QueryService<Post, ResultPostWithRelationsDto, Guid>, IPostQueryService
    {
        public PostQueryService(IReadService<Post, ResultPostWithRelationsDto, Guid> readService, IMapper mapper)
            : base(readService, mapper)
        {
        }
    }
}
