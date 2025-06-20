using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryUserServices.Write.Admin
{
    public class SearchHistoryUserAdminWriteService(
        IWriteRepository<SearchHistoryUser, Guid> writeRepository,
        IMapper mapper,
        IValidator<CreateSearchHistoryUserAdminDto> createValidator,
        IValidator<UpdateSearchHistoryUserAdminDto> updateValidator,
            AppDbContext dbContext
    )
        : WriteService<SearchHistoryUser, CreateSearchHistoryUserAdminDto, UpdateSearchHistoryUserAdminDto, Guid>(
            writeRepository,
            mapper,
            createValidator,
            updateValidator,
            dbContext
        ),
        ISearchHistoryUserAdminWriteService
    {
    }

}
