using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.SearchHistoryMutationServices
{
    public interface ISearchHistorySelfMutationService : IMutationService<SearchHistory, ResultSearchHistoryDto, CreateSearchHistoryDto, UpdateSearchHistoryDto, Guid>
    {
    }
}
