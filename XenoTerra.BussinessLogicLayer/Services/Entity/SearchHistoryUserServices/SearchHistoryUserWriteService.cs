﻿using AutoMapper;
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
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryUserServices
{
    public class SearchHistoryUserWriteService(
        IWriteRepository<SearchHistoryUser, Guid> writeRepository,
        IMapper mapper,
        IValidator<CreateSearchHistoryUserDto> createValidator,
        IValidator<UpdateSearchHistoryUserDto> updateValidator,
            AppDbContext dbContext
    )
        : WriteService<SearchHistoryUser, CreateSearchHistoryUserDto, UpdateSearchHistoryUserDto, Guid>(
            writeRepository,
            mapper,
            createValidator,
            updateValidator,
            dbContext
        ),
        ISearchHistoryUserWriteService
    {
    }

}
