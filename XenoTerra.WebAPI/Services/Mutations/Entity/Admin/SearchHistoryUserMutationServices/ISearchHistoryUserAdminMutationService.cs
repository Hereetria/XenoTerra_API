using AutoMapper;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Admin.SearchHistoryUserMutationServices
{
    public interface ISearchHistoryUserAdminMutationService : IMutationService<SearchHistoryUser, ResultSearchHistoryUserDto, CreateSearchHistoryUserDto, UpdateSearchHistoryUserDto, Guid>
    {
    }
}
