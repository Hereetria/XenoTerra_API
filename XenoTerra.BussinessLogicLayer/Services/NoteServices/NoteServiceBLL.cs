
using XenoTerra.EntityLayer.Entities;
using XenoTerra.BussinessLogicLayer.Repositories;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.BussinessLogicLayer.Services.NoteServices;
using XenoTerra.DataAccessLayer.Factories.Abstract;
namespace XenoTerra.BussinessLogicLayer.Services.NoteServices
{
     public class NoteServiceBLL : GenericRepositoryBLL<Note, ResultNoteDto, ResultNoteByIdDto, CreateNoteDto, UpdateNoteDto, Guid>, INoteServiceBLL
    {
        public NoteServiceBLL(IGenericRepositoryDALFactory repositoryDALFactory)
            : base(repositoryDALFactory)
        {
        }
    }
}