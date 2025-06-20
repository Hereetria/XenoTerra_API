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
using XenoTerra.DTOLayer.Dtos.StoryHighlightAdminDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryHighlightServices.Write.Own
{
    public class StoryHighlightOwnWriteService(
        IWriteRepository<StoryHighlight, Guid> writeRepository,
        IMapper mapper,
        IValidator<CreateStoryHighlightOwnDto> createValidator,
        IValidator<UpdateStoryHighlightOwnDto> updateValidator,
            AppDbContext dbContext
    )
        : WriteService<StoryHighlight, CreateStoryHighlightOwnDto, UpdateStoryHighlightOwnDto, Guid>(
            writeRepository,
            mapper,
            createValidator,
            updateValidator,
            dbContext
        ),
        IStoryHighlightOwnWriteService
    {
    }
}
