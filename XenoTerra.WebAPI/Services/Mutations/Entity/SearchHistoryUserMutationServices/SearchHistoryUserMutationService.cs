using AutoMapper;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.SearchHistoryUserMutationServices
{
    public class SearchHistoryUserMutationService(IMapper mapper)
        : MutationService<SearchHistoryUser, ResultSearchHistoryUserDto, CreateSearchHistoryUserDto, UpdateSearchHistoryUserDto, Guid>(mapper),
        ISearchHistoryUserMutationService
    {
    }
}
