using AutoMapper;
using XenoTerra.DTOLayer.Dtos.SearchHistoryAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.SearchHistoryMutationServices
{
    public class SearchHistoryOwnMutationService(IMapper mapper)
        : MutationService<SearchHistory, ResultSearchHistoryOwnDto, CreateSearchHistoryOwnDto, UpdateSearchHistoryOwnDto, Guid>(mapper),
        ISearchHistoryOwnMutationService
    {
    }
}
