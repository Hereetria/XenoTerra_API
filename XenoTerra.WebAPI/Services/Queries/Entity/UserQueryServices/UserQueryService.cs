using AutoMapper;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Queries.Base;

namespace XenoTerra.WebAPI.Services.Queries.Entity.UserQueryServices
{
    public class UserQueryService : BaseQueryService<User, ResultUserDto, Guid>, IUserQueryService
    {
        public UserQueryService(IReadService<User, Guid> readService, IMapper mapper)
            : base(readService, mapper) { }
    }
}
