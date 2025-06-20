using AutoMapper;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Own.SearchHistoryUserMutationServices
{
    public interface ISearchHistoryUserOwnMutationService : IMutationService<SearchHistoryUser, ResultSearchHistoryUserOwnDto, CreateSearchHistoryUserOwnDto, UpdateSearchHistoryUserOwnDto, Guid>
    {
    }
}
