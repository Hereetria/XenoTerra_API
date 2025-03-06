using Microsoft.EntityFrameworkCore;
using XenoTerra.BussinessLogicLayer.Services.UserServices;
using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.Schemas.DataLoaders
{
    public class UserDataLoader : BatchDataLoader<Guid, ResultUserDto>
    {
        private readonly IUserServiceBLL _userServiceBLL;
        public UserDataLoader(IBatchScheduler batchScheduler, DataLoaderOptions options, IUserServiceBLL userServiceBLL) : base(batchScheduler, options)
        {
            _userServiceBLL = userServiceBLL;
        }

        protected override async Task<IReadOnlyDictionary<Guid, ResultUserDto>> LoadBatchAsync(
            IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            var users = await _userServiceBLL.GetByIdsQuerable(keys).ToListAsync(cancellationToken);
            return users.ToDictionary(user => user.Id);
        }

    }
}
