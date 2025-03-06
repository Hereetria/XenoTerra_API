using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.WebAPI.Schemas.DataLoaders;

namespace XenoTerra.WebAPI.Schemas.Resolvers
{
    public class BlockUserResolver
    {
        public async Task<ResultUserDto?> GetBlockingUserAsync(
            [Parent] ResultBlockUserWithRelationsDto blockUser,
            UserDataLoader userDataLoader)
        {
            return await userDataLoader.LoadAsync(blockUser.BlockingUserId);
        }

        public async Task<ResultUserDto?> GetBlockedUserAsync(
            [Parent] ResultBlockUserWithRelationsDto blockUser,
            UserDataLoader userDataLoader)
        {
            return await userDataLoader.LoadAsync(blockUser.BlockedUserId);
        }
    }

}
