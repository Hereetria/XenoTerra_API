using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Write;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.NoteService
{
    public class NoteWriteService : WriteService<Note, ResultNoteDto, CreateNoteDto, UpdateNoteDto, Guid>, INoteWriteService
    {
        public NoteWriteService(IWriteRepository<Note, ResultNoteDto, Guid> repository, IMapper mapper)
            : base(repository, mapper) { }
    }

}
