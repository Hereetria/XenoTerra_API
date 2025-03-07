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
                .ResolveWith<BlockUserResolver>(r => r.GetBlockingUserAsync(default!, default!, default!));

            descriptor.Field(x => x.BlockedUser)
                .ResolveWith<BlockUserResolver>(r => r.GetBlockedUserAsync(default!, default!, default!));
        }
    }


}