using AutoMapper;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.SearchHistoryUserMutationServices
{
    public class SearchHistoryUserAdminMutationService(IMapper mapper)
        : MutationService<SearchHistoryUser, ResultSearchHistoryUserDto, CreateSearchHistoryUserDto, UpdateSearchHistoryUserDto, Guid>(mapper),
        ISearchHistoryUserAdminMutationService
    {
    }
}
