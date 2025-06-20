using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.SearchHistoryAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.SearchHistoryMutationServices
{
    public interface ISearchHistoryAdminMutationService : IMutationService<SearchHistory, ResultSearchHistoryAdminDto, CreateSearchHistoryAdminDto, UpdateSearchHistoryAdminDto, Guid>
    {
    }
}