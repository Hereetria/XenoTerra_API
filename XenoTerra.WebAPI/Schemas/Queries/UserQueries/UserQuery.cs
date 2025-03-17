using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserService;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.UserResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.UserQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.UserQueries
{
    public class UserQuery
    {
        private readonly IMapper _mapper;

        public UserQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultUserWithRelationsDto>> GetAllUsersAsync(
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            IResolverContext context)
        {
            var users = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(users, context);
            var userDtos = _mapper.Map<List<ResultUserWithRelationsDto>>(users);
            return userDtos;
        }

        public async Task<IEnumerable<ResultUserWithRelationsDto>> GetUsersByIdsAsync(
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var users = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(users, context);
            var userDtos = _mapper.Map<List<ResultUserWithRelationsDto>>(users);
            return userDtos;
        }

        public async Task<ResultUserWithRelationsDto> GetUserByIdAsync(
            [Service] IUserQueryService service,
            [Service] IUserResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var user = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(user, context);
            var userDto = _mapper.Map<ResultUserWithRelationsDto>(user);
            return userDto;
        }
    }

}
