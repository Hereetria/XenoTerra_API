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
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.HighlightServices
{
    public class HighlightWriteService(
            IWriteRepository<Highlight, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateHighlightDto> createValidator,
            IValidator<UpdateHighlightDto> updateValidator,
                    AppDbContext dbContext
        )
            : WriteService<Highlight, CreateHighlightDto, UpdateHighlightDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IHighlightWriteService
    {
    }
}
