using AutoMapper;
using XenoTerra.DTOLayer.Dtos.ReactionDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.ReactionResolvers
{

    public class ReactionResolver : EntityResolver<Reaction, ResultReactionWithRelationsDto, Guid>, IReactionResolver
    {
        public ReactionResolver(EntityDataLoaderFactory entityDataLoaderFactory)
            : base(entityDataLoaderFactory) { }
    }
}
