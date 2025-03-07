using GreenDonut;
using HotChocolate.Language;
using HotChocolate.Resolvers;
using XenoTerra.BussinessLogicLayer.Services.BlockUserServices;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders;

namespace XenoTerra.WebAPI.Schemas.Resolvers
{
    public class BlockUserResolver
    {
        //public async Task<IEnumerable<ResultBlockUserWithRelationsDto>> GetBlockUsersAsync(
        //      List<Guid>? ids,
        //      [Service] IBlockUserServiceBLL service,
        //      IResolverContext context)
        //{
        //    var selectedFields = context.Selection.SyntaxNode.SelectionSet?.Selections
        //        .OfType<FieldNode>()
        //        .Select(s => s.Name.Value)
        //        .ToList() ?? new List<string>();

        //    var result = await service.GetByIdsWithRelationsAsync(
        //        ids ?? await service.GetAllIdsAsync(),
        //        selectedFields
        //    );

        //    return result;
        //}

        public async Task<ResultUserDto?> GetBlockingUserAsync(
          [Parent] ResultBlockUserWithRelationsDto blockUserDto,
          UserDataLoader dataLoader,
          IResolverContext context)
        {
            var selectedFields = context.Selection.SyntaxNode.SelectionSet?.Selections
                .OfType<FieldNode>()
                .Select(s => s.Name.Value)
                .ToList() ?? new List<string>();

            Console.WriteLine($"Selected Fields for BlockingUser: {string.Join(", ", selectedFields)}");

            var user = await dataLoader.LoadAsync(blockUserDto.BlockingUserId);

            // ✅ Eğer kullanıcı bulunduysa DTO'ya atama yap
            if (user != null)
            {
                blockUserDto.BlockingUser = new ResultUserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName
                };
            }

            return user;
        }

        [UseProjection]
        public async Task<ResultUserDto?> GetBlockedUserAsync(
            [Parent] ResultBlockUserWithRelationsDto blockUserDto,
            UserDataLoader dataLoader,
            IResolverContext context)
        {
            var selectedFields = context.Selection.SyntaxNode.SelectionSet?.Selections
                .OfType<FieldNode>()
                .Select(s => s.Name.Value)
                .ToList() ?? new List<string>();

            return await dataLoader.LoadAsync(blockUserDto.BlockingUserId);
        }
    }





}
