using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.PostTagDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.UserPostTagQueryServices
{
    public class UserPostTagQueryService : BaseQueryService<UserPostTag, ResultUserPostTagDto, Guid>, IUserPostTagQueryService
    {
        public UserPostTagQueryService(IReadService<UserPostTag, Guid> readService, IMapper mapper)
            : base(readService, mapper) { }
    }
}
