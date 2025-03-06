
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.DataAccessLayer.Repositories;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Services.NoteServices
{
    
    public interface INoteServiceDAL : IGenericRepositoryDAL<Note, ResultNoteDto, ResultNoteWithRelationsDto, CreateNoteDto, UpdateNoteDto, Guid>

    {

    }
}