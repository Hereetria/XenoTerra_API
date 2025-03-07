using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.NoteServices;
using XenoTerra.DTOLayer.Dtos.NoteDtos;

namespace XenoTerra.WebAPI.Schemas.Queries.Note
{
    public class NoteQuery
    {
        public string GetRandomData()
        {
            return "Default data to prevent query class from being empty.";
        }

        //[UseProjection]
        //[GraphQLDescription("Get all Notes")]
        //public IQueryable<ResultNoteDto> GetAllNotes([Service] INoteServiceBLL noteServiceBLL)
        //{
        //    return noteServiceBLL.GetAllQuerable();
        //}

        //[UseProjection]
        //[GraphQLDescription("Get Note by ID")]
        //public IQueryable<ResultNoteByIdDto> GetNoteById(Guid id, [Service] INoteServiceBLL noteServiceBLL)
        //{
        //    var result = noteServiceBLL.GetByIdQuerable(id);
        //    if (result == null)
        //    {
        //        throw new Exception($"Note with ID {id} not found");
        //    }
        //    return result;
        //}
    }
}
