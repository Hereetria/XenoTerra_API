using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.BlockUserResolvers
{
    public class BlockUserResolver : EntityResolver<BlockUser, Guid>, IBlockUserResolver
    {
        public BlockUserResolver(IEntityFieldMapBuilder<BlockUser, Guid> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : base(entityFieldMapBuilder, dataLoaderInvoker)
        {
        }
    }

}

