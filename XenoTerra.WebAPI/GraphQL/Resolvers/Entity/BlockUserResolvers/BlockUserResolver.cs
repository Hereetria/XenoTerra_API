using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.GraphQL.Resolvers.Entity.BlockUserResolvers
{
    public class BlockUserResolver : EntityResolver<BlockUser, Guid>, IBlockUserResolver
    {
        public BlockUserResolver(IEntityFieldMapBuilder<BlockUser, Guid> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : base(entityFieldMapBuilder, dataLoaderInvoker)
        {
        }
    }

}

