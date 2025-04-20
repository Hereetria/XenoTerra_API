using AutoMapper;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;
using XenoTerra.WebAPI.Services.Mutations.Entity.SearchHistoryMutationServices;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.SearchHistoryUserMutationServices
{
    public interface ISearchHistoryUserMutationService : IMutationService<SearchHistoryUser, ResultSearchHistoryUserDto, CreateSearchHistoryUserDto, UpdateSearchHistoryUserDto, Guid>
    {
    }
}
