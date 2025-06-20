using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserAdminDtos.Admin;
namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.SearchHistoryUserMutationServices
{
    public interface ISearchHistoryUserAdminMutationService : IMutationService<SearchHistoryUser, ResultSearchHistoryUserAdminDto, CreateSearchHistoryUserAdminDto, UpdateSearchHistoryUserAdminDto, Guid>
    {
    }
}