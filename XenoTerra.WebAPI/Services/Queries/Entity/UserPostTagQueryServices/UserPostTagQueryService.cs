using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.UserPostTagQueryServices
{
    public class UserPostTagQueryService : QueryService<UserPostTag, ResultUserPostTagWithRelationsDto, Guid>, IUserPostTagQueryService
    {
        public UserPostTagQueryService(IReadService<UserPostTag, ResultUserPostTagWithRelationsDto, Guid> readService, IMapper mapper)
            : base(readService, mapper) { }
    }
}
