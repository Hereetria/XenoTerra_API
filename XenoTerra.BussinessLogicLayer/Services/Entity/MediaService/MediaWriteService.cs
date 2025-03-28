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
using XenoTerra.DTOLayer.Dtos.MediaDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.MediaService
{
    public class MediaWriteService(
            IWriteRepository<Media, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateMediaDto> createValidator,
            IValidator<UpdateMediaDto> updateValidator
        )
            : WriteService<Media, CreateMediaDto, UpdateMediaDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator
            ),
            IMediaWriteService
    {
    }
}
