using AutoMapper;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.SearchHistoryUserMutationServices
{
    public class SearchHistoryUserSelfMutationService(IMapper mapper)
        : MutationService<SearchHistoryUser, ResultSearchHistoryUserDto, CreateSearchHistoryUserDto, UpdateSearchHistoryUserDto, Guid>(mapper),
        ISearchHistoryUserSelfMutationService
    {
    }
}
