using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.PostQueryServices
{
    public class PostQueryService : QueryService<Post, Guid>, IPostQueryService
    {
        public PostQueryService(IReadService<Post, Guid> readService, IMapper mapper)
            : base(readService, mapper) { }
    }
}
