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
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.HighlightService
{
    public class HighlightWriteService(
            IWriteRepository<Highlight, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateHighlightDto> createValidator,
            IValidator<UpdateHighlightDto> updateValidator
        )
            : WriteService<Highlight, CreateHighlightDto, UpdateHighlightDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator
            ),
            IHighlightWriteService
    {
    }
}
