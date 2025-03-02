

using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.DataAccessLayer.Repositories;

namespace XenoTerra.DataAccessLayer.Services.NoteServices
{
    
    public class NoteServiceDAL : GenericRepositoryDAL<Note, ResultNoteDto, ResultNoteByIdDto, CreateNoteDto, UpdateNoteDto, Guid>, INoteServiceDAL

    {

        public NoteServiceDAL(Context context, IMapper mapper)
            : base(context, mapper)
        {
        }

    }
}