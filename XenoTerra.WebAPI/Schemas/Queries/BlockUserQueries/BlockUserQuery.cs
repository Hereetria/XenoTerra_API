using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Services.Queries.Entity.BlockUserQueryServices;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.BlockUserQueries
{
    public class BlockUserQuery
    {
        private readonly IBlockUserQueryService _blockUserQueryService;
        private readonly BlockUserResolver _resolver;

        public BlockUserQuery(IBlockUserQueryService blockUserQueryService, BlockUserResolver resolver)
        {
            _blockUserQueryService = blockUserQueryService;
            _resolver = resolver;
        }

        public async Task<IEnumerable<ResultBlockUserWithRelationsDto>> GetAllBlockUsersAsync([Service] IResolverContext context)
        {
            var result = await _blockUserQueryService.GetAllAsync(context);
            await _resolver.PopulateRelatedFieldsAsync(result, context);
            return result;
        }

        public async Task<IEnumerable<ResultBlockUserWithRelationsDto>> GetBlockUsersByIdsAsync(List<Guid> keys, IResolverContext context)
        {
            var result = await _blockUserQueryService.GetByIdsAsync(keys, context);
            await _resolver.PopulateRelatedFieldsAsync(result, context);
            return result;
        }

        public async Task<ResultBlockUserWithRelationsDto> GetBlockUserByIdAsync(Guid key, IResolverContext context)
        {
            var result = await _blockUserQueryService.GetByIdAsync(key, context);
            await _resolver.PopulateRelatedFieldAsync(result, context);
            return result;
        }
    }
}
