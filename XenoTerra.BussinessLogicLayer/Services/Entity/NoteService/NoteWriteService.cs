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
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.NoteService
{
    public class NoteWriteService(
            IWriteRepository<Note, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateNoteDto> createValidator,
            IValidator<UpdateNoteDto> updateValidator
        )
            : WriteService<Note, CreateNoteDto, UpdateNoteDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator
            ),
            INoteWriteService
    {
    }
}
