using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryHighlightServices
{
    public class StoryHighlightWriteService(
        IWriteRepository<StoryHighlight, Guid> writeRepository,
        IMapper mapper,
        IValidator<CreateStoryHighlightDto> createValidator,
        IValidator<UpdateStoryHighlightDto> updateValidator
    )
        : WriteService<StoryHighlight, CreateStoryHighlightDto, UpdateStoryHighlightDto, Guid>(
            writeRepository,
            mapper,
            createValidator,
            updateValidator
        ),
        IStoryHighlightWriteService
    {
    }
}
