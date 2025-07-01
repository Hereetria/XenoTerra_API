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
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.HighlightServices.Write.Own
{
    public class HighlightOwnWriteService(
            IWriteRepository<Highlight, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateHighlightOwnDto> createValidator,
            IValidator<UpdateHighlightOwnDto> updateValidator,
                    AppDbContext dbContext
        )
            : WriteService<Highlight, CreateHighlightOwnDto, UpdateHighlightOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IHighlightOwnWriteService
    {
    }
}
