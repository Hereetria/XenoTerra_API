using XenoTerra.DTOLayer.Dtos.SearchHistoryAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.SearchHistoryMutationServices
{
    public interface ISearchHistoryOwnMutationService : IMutationService<SearchHistory, ResultSearchHistoryOwnDto, CreateSearchHistoryOwnDto, UpdateSearchHistoryOwnDto, Guid>
    {
    }
}
