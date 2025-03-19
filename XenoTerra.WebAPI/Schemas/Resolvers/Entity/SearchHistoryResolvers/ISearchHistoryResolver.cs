using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.SearchHistoryResolvers
{
    public interface ISearchHistoryResolver : IEntityResolver<SearchHistory, ResultSearchHistoryWithRelationsDto, Guid>
    {
    }
}
