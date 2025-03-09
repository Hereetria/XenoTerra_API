using GreenDonut;
using HotChocolate.Language;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.BlockUserServices;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders;

namespace XenoTerra.WebAPI.Schemas.Resolvers
{
    public class BlockUserResolver
    {
        public async Task PopulateBlockUsersAsync(
            [Parent] ResultBlockUserWithRelationsDto blockUserDto,
            UserDataLoader userDataLoader,
            IResolverContext context)
        {
            var selectedFields = GetSelectedFields(context);

            var userIds = new List<Guid>();
            if (blockUserDto.BlockingUserId != Guid.Empty)
                userIds.Add(blockUserDto.BlockingUserId);
            if (blockUserDto.BlockedUserId != Guid.Empty)
                userIds.Add(blockUserDto.BlockedUserId);

            if (!userIds.Any())
                return;

            var usersDict = await userDataLoader.LoadAsync(userIds, selectedFields);

            if (usersDict.TryGetValue(blockUserDto.BlockingUserId, out var blockingUser))
                blockUserDto.BlockingUser = blockingUser;

            if (usersDict.TryGetValue(blockUserDto.BlockedUserId, out var blockedUser))
                blockUserDto.BlockedUser = blockedUser;
        }

        private List<string> GetSelectedFields(IResolverContext context)
        {
            return context.Selection.SyntaxNode.SelectionSet?.Selections
                .OfType<FieldNode>()
                .Select(s => s.Name.Value)
                .ToList() ?? new List<string>();
        }
    }

}

