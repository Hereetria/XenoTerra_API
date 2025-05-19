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
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryHighlightServices
{
    public class StoryHighlightWriteService(
        IWriteRepository<StoryHighlight, Guid> writeRepository,
        IMapper mapper,
        IValidator<CreateStoryHighlightDto> createValidator,
        IValidator<UpdateStoryHighlightDto> updateValidator,
            AppDbContext dbContext
    )
        : WriteService<StoryHighlight, CreateStoryHighlightDto, UpdateStoryHighlightDto, Guid>(
            writeRepository,
            mapper,
            createValidator,
            updateValidator,
            dbContext
        ),
        IStoryHighlightWriteService
    {
    }
}
