using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.SearchHistoryMutationServices
{
    public interface ISearchHistoryAdminMutationService : IMutationService<SearchHistory, ResultSearchHistoryDto, CreateSearchHistoryDto, UpdateSearchHistoryDto, Guid>
    {
    }
}
