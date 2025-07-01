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
using XenoTerra.DTOLayer.Dtos.NoteDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.NoteServices.Write.Own
{
    public class NoteOwnWriteService(
            IWriteRepository<Note, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateNoteOwnDto> createValidator,
            IValidator<UpdateNoteOwnDto> updateValidator,
            AppDbContext dbContext
        )
            : WriteService<Note, CreateNoteOwnDto, UpdateNoteOwnDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator,
                dbContext
            ),
            INoteOwnWriteService
    {
        protected override Task PreCreateAsync(CreateNoteOwnDto createDto)
        {
            createDto.CreatedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
