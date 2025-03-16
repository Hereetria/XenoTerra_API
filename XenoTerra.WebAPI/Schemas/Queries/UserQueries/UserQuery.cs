using AutoMapper;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserService;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers;
using XenoTerra.WebAPI.Utils;

namespace XenoTerra.WebAPI.Schemas.Queries.UserQueries
{
    public class UserQuery
    {
        public async Task<IEnumerable<ResultUserWithRelationsDto>> GetAllUsersAsync(
            [Service] IUserReadService userReadService,
            [Service] UserResolver resolver,
            [Service] IMapper mapper,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = userReadService.FetchAllQueryable(selectedFields)
                ?? Enumerable.Empty<User>().AsQueryable();

            var users = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(users, context);

            return mapper.Map<List<ResultUserWithRelationsDto>>(users);
        }

        public async Task<IEnumerable<ResultUserWithRelationsDto>> GetUsersByIdsAsync(
            [Service] IUserReadService userReadService,
            [Service] UserResolver resolver,
            [Service] IMapper mapper,
            List<Guid> keys,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = userReadService.FetchByIdsQueryable(keys, selectedFields)
                ?? Enumerable.Empty<User>().AsQueryable();

            var users = await query.ToListAsync();
            await resolver.PopulateRelatedFieldsAsync(users, context);

            return mapper.Map<List<ResultUserWithRelationsDto>>(users);
        }

        public async Task<ResultUserWithRelationsDto> GetUserByIdAsync(
            [Service] IUserReadService userReadService,
            [Service] UserResolver resolver,
            [Service] IMapper mapper,
            Guid key,
            IResolverContext context)
        {
            var selectedFields = SelectedFieldsProvider.GetSelectedFields(context);
            var query = userReadService.FetchByIdQueryable(key, selectedFields)
                ?? Enumerable.Empty<User>().AsQueryable();

            var user = await query.FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"User with ID {key} was not found in the database.");

            await resolver.PopulateRelatedFieldAsync(user, context);

            return mapper.Map<ResultUserWithRelationsDto>(user);
        }
    }
}
