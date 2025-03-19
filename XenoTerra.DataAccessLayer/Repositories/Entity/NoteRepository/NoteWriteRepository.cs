using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.NoteRepository
{

    public class NoteWriteRepository : WriteRepository<Note, ResultNoteDto, Guid>, INoteWriteRepository
    {
        public NoteWriteRepository(IMapper mapper, AppDbContext context) : base(mapper, context)
        {
        }
    }

}
