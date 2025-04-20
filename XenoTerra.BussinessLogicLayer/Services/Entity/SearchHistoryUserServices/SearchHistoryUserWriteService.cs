using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryUserServices
{
    public class SearchHistoryUserWriteService(
        IWriteRepository<SearchHistoryUser, Guid> writeRepository,
        IMapper mapper,
        IValidator<CreateSearchHistoryUserDto> createValidator,
        IValidator<UpdateSearchHistoryUserDto> updateValidator
    )
        : WriteService<SearchHistoryUser, CreateSearchHistoryUserDto, UpdateSearchHistoryUserDto, Guid>(
            writeRepository,
            mapper,
            createValidator,
            updateValidator
        ),
        ISearchHistoryUserWriteService
    {
    }

}
