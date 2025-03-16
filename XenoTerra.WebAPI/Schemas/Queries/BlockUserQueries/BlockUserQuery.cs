using AutoMapper;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.BlockUserQueries
{
    public class BlockUserQuery
    {
        public async Task<IEnumerable<ResultBlockUserWithRelationsDto>> GetAllBlockUsersAsync(
            [Service] IBlockUserReadService blockUserReadService,
            [Service] BlockUserResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = blockUserReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<BlockUser>().AsQueryable();

            var blockUsers = await query.ToListAsync();


            await resolver.PopulateRelatedFieldsAsync(blockUsers, context);

            var result = mapper.Map<List<ResultBlockUserWithRelationsDto>>(blockUsers);

            return result;
        }

        public async Task<IEnumerable<ResultBlockUserWithRelationsDto>> GetBlockUsersByIdsAsync(
            [Service] IBlockUserReadService blockUserReadService,
            [Service] BlockUserResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = blockUserReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<BlockUser>().AsQueryable();

            var blockUsers = await query.ToListAsync();


            await resolver.PopulateRelatedFieldsAsync(blockUsers, context);

            var result = mapper.Map<List<ResultBlockUserWithRelationsDto>>(blockUsers);

            return result;
        }

        public async Task<ResultBlockUserWithRelationsDto> GetBlockUserByIdAsync(
            [Service] IBlockUserReadService blockUserReadService,
            [Service] BlockUserResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = blockUserReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<BlockUser>().AsQueryable();

            var blockUser = await query.FirstOrDefaultAsync()
                ?? throw new System.Collections.Generic.KeyNotFoundException($"BlockUser with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(blockUser, context);

            var result = mapper.Map<ResultBlockUserWithRelationsDto>(blockUser);

            return result;
        }
    }
}
