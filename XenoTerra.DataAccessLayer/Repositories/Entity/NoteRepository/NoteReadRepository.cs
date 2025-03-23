using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.NoteRepository
{
    public class NoteReadRepository : ReadRepository<Note, Guid>, INoteReadRepository
    {
        public NoteReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
