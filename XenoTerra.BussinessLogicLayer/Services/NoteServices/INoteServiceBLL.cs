
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;
namespace XenoTerra.BussinessLogicLayer.Services.NoteServices
{
        public interface INoteServiceBLL : IGenericRepositoryBLL<Note, ResultNoteDto, ResultNoteByIdDto, CreateNoteDto, UpdateNoteDto, Guid>
    {

    }
}