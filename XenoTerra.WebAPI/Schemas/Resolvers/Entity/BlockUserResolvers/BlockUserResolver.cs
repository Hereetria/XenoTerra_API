using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.BlockUserResolvers
{
    public class BlockUserResolver : EntityResolver<BlockUser, Guid>, IBlockUserResolver
    {
        public BlockUserResolver(EntityDataLoaderFactory entityDataLoaderFactory, IMapper mapper) : base(entityDataLoaderFactory, mapper)
        {
        }
    }

}

