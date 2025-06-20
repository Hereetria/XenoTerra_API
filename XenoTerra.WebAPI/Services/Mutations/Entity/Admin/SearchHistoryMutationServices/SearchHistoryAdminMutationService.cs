using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.SearchHistoryAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.SearchHistoryMutationServices
{
    public class SearchHistoryAdminMutationService(IMapper mapper)
        : MutationService<SearchHistory, ResultSearchHistoryAdminDto, CreateSearchHistoryAdminDto, UpdateSearchHistoryAdminDto, Guid>(mapper),
        ISearchHistoryAdminMutationService
    {
    }
}