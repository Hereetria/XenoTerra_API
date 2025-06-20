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
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.StoryHighlightAdminDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryHighlightServices.Write.Admin
{
    public class StoryHighlightAdminWriteService(
        IWriteRepository<StoryHighlight, Guid> writeRepository,
        IMapper mapper,
        IValidator<CreateStoryHighlightAdminDto> createValidator,
        IValidator<UpdateStoryHighlightAdminDto> updateValidator,
            AppDbContext dbContext
    )
        : WriteService<StoryHighlight, CreateStoryHighlightAdminDto, UpdateStoryHighlightAdminDto, Guid>(
            writeRepository,
            mapper,
            createValidator,
            updateValidator,
            dbContext
        ),
        IStoryHighlightAdminWriteService
    {
    }
}
