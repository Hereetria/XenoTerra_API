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
using XenoTerra.DTOLayer.Dtos.HighlightDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.HighlightServices.Write.Admin
{
    public class HighlightAdminWriteService(
            IWriteRepository<Highlight, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateHighlightAdminDto> createValidator,
            IValidator<UpdateHighlightAdminDto> updateValidator,
                    AppDbContext dbContext
        )
            : WriteService<Highlight, CreateHighlightAdminDto, UpdateHighlightAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            IHighlightAdminWriteService
    {
    }
}
