using HotChocolate.Types;
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
            descriptor.Field(x => x.BlockingUser)
                .ResolveWith<BlockUserResolver>(x => x.GetBlockingUserAsync(default!, default!))
                .UseDataLoader(typeof(UserDataLoader));

            descriptor.Field(x => x.BlockedUser)
                .ResolveWith<BlockUserResolver>(x => x.GetBlockedUserAsync(default!, default!))
                .UseDataLoader(typeof(UserDataLoader));
        }
    }
}
