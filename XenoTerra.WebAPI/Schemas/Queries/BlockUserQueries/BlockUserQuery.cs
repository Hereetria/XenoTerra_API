using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.BlockUserResolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.BlockUserQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.BlockUserQueries
{
    public class BlockUserQuery
    {
        private readonly IMapper _mapper;

        public BlockUserQuery(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<ResultBlockUserWithRelationsDto>> GetAllBlockUsersAsync(
            [Service] IBlockUserQueryService service,
            [Service] IBlockUserResolver resolver, 
            IResolverContext context)
        {
            var blockUsers = await service.GetAllAsync(context);
            await resolver.PopulateRelatedFieldsAsync(blockUsers, context);
            var blockUserDtos = _mapper.Map<List<ResultBlockUserWithRelationsDto>>(blockUsers);
            return blockUserDtos;
        }

        public async Task<IEnumerable<ResultBlockUserWithRelationsDto>> GetBlockUsersByIdsAsync(
            [Service] IBlockUserQueryService service,
            [Service] IBlockUserResolver resolver,
            IEnumerable<Guid> keys,
            IResolverContext context)
        {
            var blockUsers = await service.GetByIdsAsync(keys, context);
            await resolver.PopulateRelatedFieldsAsync(blockUsers, context);
            var blockUserDtos = _mapper.Map<List<ResultBlockUserWithRelationsDto>>(blockUsers);
            return blockUserDtos;
        }

        public async Task<ResultBlockUserWithRelationsDto> GetBlockUserByIdAsync([Service] IBlockUserQueryService service,
            [Service] IBlockUserResolver resolver,
            Guid key,
            IResolverContext context)
        {
            var blockUser = await service.GetByIdAsync(key, context);
            await resolver.PopulateRelatedFieldAsync(blockUser, context);
            var blockUserDto = _mapper.Map<ResultBlockUserWithRelationsDto>(blockUser);
            return blockUserDto;
        }
    }
}
