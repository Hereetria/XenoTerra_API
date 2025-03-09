using HotChocolate.Language;
using HotChocolate.Language.Utilities;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using System.Reflection;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.WebAPI.Schemas.DataLoaders;
using XenoTerra.WebAPI.Schemas.Resolvers;

namespace XenoTerra.WebAPI.Schemas.Types
{
    public class ResultBlockUserDtoType : ObjectType<ResultBlockUserWithRelationsDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ResultBlockUserWithRelationsDto> descriptor)
        {
            descriptor
                .Field(x => x.BlockingUser)
                .Resolve(async context =>
                {
                    var blockUserDto = context.Parent<ResultBlockUserWithRelationsDto>();
                    var userDataLoader = context.Service<UserDataLoader>();
                    var resolver = context.Service<BlockUserResolver>();

                    await resolver.PopulateBlockUsersAsync(blockUserDto, userDataLoader, context);

                    return blockUserDto.BlockingUser;
                });

            descriptor
                .Field(x => x.BlockedUser)
                .Resolve(async context =>
                {
                    var blockUserDto = context.Parent<ResultBlockUserWithRelationsDto>();
                    var userDataLoader = context.Service<UserDataLoader>();
                    var resolver = context.Service<BlockUserResolver>();

                    await resolver.PopulateBlockUsersAsync(blockUserDto, userDataLoader, context);

                    return blockUserDto.BlockedUser;
                });
        }

    }


}