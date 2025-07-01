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
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.NoteDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.NoteServices.Write.Admin
{
    public class NoteAdminWriteService(
            IWriteRepository<Note, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateNoteAdminDto> createValidator,
            IValidator<UpdateNoteAdminDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Note, CreateNoteAdminDto, UpdateNoteAdminDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            INoteAdminWriteService
    {
        protected override Task PreCreateAsync(CreateNoteAdminDto createDto)
        {
            createDto.CreatedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
