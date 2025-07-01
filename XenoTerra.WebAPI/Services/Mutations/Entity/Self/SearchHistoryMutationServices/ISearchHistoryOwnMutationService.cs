using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.SearchHistoryMutationServices
{
    public interface ISearchHistoryOwnMutationService : IMutationService<SearchHistory, ResultSearchHistoryOwnDto, CreateSearchHistoryOwnDto, UpdateSearchHistoryOwnDto, Guid>
    {
    }
}
