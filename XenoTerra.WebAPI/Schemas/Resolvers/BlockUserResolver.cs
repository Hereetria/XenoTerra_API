using GreenDonut;
using HotChocolate.Resolvers;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders;

namespace XenoTerra.WebAPI.Schemas.Resolvers
{
    public class BlockUserResolver
    {
        public async Task<ResultUserDto?> GetBlockingUserAsync(
            [Parent] ResultBlockUserWithRelationsDto blockUserDto,
            UserDataLoader dataLoader,
            IResolverContext context)
        {
            var objectType = context.Selection.Type as IObjectType;
            if (objectType is null)
            {
                throw new Exception("Object type could not be determined.");
            }

            var selectedFields = context.GetSelections(objectType)
                                        .Select(s => s.ResponseName)
                                        .ToList();

            return await dataLoader.LoadAsync(blockUserDto.BlockingUserId, selectedFields);
        }



        [UseProjection]
        public async Task<ResultUserDto?> GetBlockedUserAsync(
            [Parent] ResultBlockUserWithRelationsDto blockUserDto,
            UserDataLoader dataLoader,
            IResolverContext context)
        {
            var objectType = context.Selection.Type as IObjectType;
            if (objectType is null)
            {
                throw new Exception("Object type could not be determined.");
            }

            var selectedFields = context.GetSelections(objectType)
                                        .Select(s => s.ResponseName)
                                        .ToList();

            return await dataLoader.LoadAsync(blockUserDto.BlockingUserId, selectedFields);
        }
    }




}
