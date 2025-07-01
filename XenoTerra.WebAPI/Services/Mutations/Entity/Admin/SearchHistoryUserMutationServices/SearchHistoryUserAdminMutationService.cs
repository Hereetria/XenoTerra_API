using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.SearchHistoryUserMutationServices
{
    public class SearchHistoryUserAdminMutationService(IMapper mapper)
        : MutationService<SearchHistoryUser, ResultSearchHistoryUserAdminDto, CreateSearchHistoryUserAdminDto, UpdateSearchHistoryUserAdminDto, Guid>(mapper),
        ISearchHistoryUserAdminMutationService
    {
    }
}