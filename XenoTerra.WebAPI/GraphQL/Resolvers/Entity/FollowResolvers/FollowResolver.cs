using AutoMapper;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Resolvers.Base;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.FollowResolvers;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.GraphQL.Resolvers.Entity.FollowResolvers;

public class FollowResolver : EntityResolver<Follow, Guid>, IFollowResolver
{
    public FollowResolver(IEntityFieldMapBuilder<Follow, Guid> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : base(entityFieldMapBuilder, dataLoaderInvoker)
    {
    }
}
