using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.ViewStoryService
{
    public class ViewStoryWriteService(
            IWriteRepository<ViewStory, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateViewStoryDto> createValidator,
            IValidator<UpdateViewStoryDto> updateValidator
        )
            : WriteService<ViewStory, CreateViewStoryDto, UpdateViewStoryDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator
            ),
            IViewStoryWriteService
    {
    }
}
