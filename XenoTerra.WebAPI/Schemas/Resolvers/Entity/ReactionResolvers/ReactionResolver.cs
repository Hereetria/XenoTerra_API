using AutoMapper;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ReactionResolvers
{

    public class ReactionResolver : EntityResolver<Reaction, ResultReactionWithRelationsDto, Guid>, IReactionResolver
    {
        public ReactionResolver(IEntityFieldMapBuilder<Reaction, ResultReactionWithRelationsDto, Guid> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : base(entityFieldMapBuilder, dataLoaderInvoker)
        {
        }
    }
}
