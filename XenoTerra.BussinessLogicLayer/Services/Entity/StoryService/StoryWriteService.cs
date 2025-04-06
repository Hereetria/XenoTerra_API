using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.StoryService
{
    public class StoryWriteService(
            IWriteRepository<Story, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateStoryDto> createValidator,
            IValidator<UpdateStoryDto> updateValidator
        )
            : WriteService<Story, CreateStoryDto, UpdateStoryDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator
            ),
            IStoryWriteService
    {
    }
}
