using AutoMapper;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.SearchHistoryUserMutationServices
{
    public class SearchHistoryUserOwnMutationService(IMapper mapper)
        : MutationService<SearchHistoryUser, ResultSearchHistoryUserOwnDto, CreateSearchHistoryUserOwnDto, UpdateSearchHistoryUserOwnDto, Guid>(mapper),
        ISearchHistoryUserOwnMutationService
    {
    }
}
