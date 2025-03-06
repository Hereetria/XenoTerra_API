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
                .Resolve(async context =>
                {
                    var blockUserDto = context.Parent<ResultBlockUserWithRelationsDto>();
                    var dataLoader = context.Service<UserDataLoader>();
                    return await dataLoader.LoadAsync(blockUserDto.BlockingUserId);
                })
                .UseDataLoader<UserDataLoader>();

            descriptor.Field(x => x.BlockedUser)
                .Resolve(async context =>
                {
                    var blockUserDto = context.Parent<ResultBlockUserWithRelationsDto>();
                    var dataLoader = context.Service<UserDataLoader>();
                    return await dataLoader.LoadAsync(blockUserDto.BlockedUserId);
                })
                .UseDataLoader<UserDataLoader>();
        }
    }

}