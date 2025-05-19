using AutoMapper;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.SearchHistoryMutationServices
{
    public class SearchHistoryAdminMutationService(IMapper mapper)
        : MutationService<SearchHistory, ResultSearchHistoryDto, CreateSearchHistoryDto, UpdateSearchHistoryDto, Guid>(mapper),
        ISearchHistoryAdminMutationService
    {
    }
}
