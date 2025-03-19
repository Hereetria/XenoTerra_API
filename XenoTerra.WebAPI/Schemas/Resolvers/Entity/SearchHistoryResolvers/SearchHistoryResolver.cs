using AutoMapper;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;
using XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.SearchHistoryResolvers;

namespace XenoTerra.WebAPI.Schemas.Resolvers
{
    public class SearchHistoryResolver : EntityResolver<SearchHistory, ResultSearchHistoryWithRelationsDto, Guid>, ISearchHistoryResolver
    {
        public SearchHistoryResolver(EntityDataLoaderFactory entityDataLoaderFactory) : base(entityDataLoaderFactory)
        {
        }
    }

}
