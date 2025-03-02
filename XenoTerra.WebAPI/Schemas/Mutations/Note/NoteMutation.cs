using HotChocolate;
using XenoTerra.BussinessLogicLayer.Services.NoteServices;
using XenoTerra.DTOLayer.Dtos.NoteDtos;

namespace XenoTerra.WebAPI.Schemas.Mutations.Note
{
    public class NoteMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Note")]
        public async Task<ResultNoteByIdDto> CreateNoteAsync(CreateNoteDto createNoteDto, [Service] INoteServiceBLL noteServiceBLL)
        {
            var result = await noteServiceBLL.CreateAsync(createNoteDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Note")]
        public async Task<ResultNoteByIdDto> UpdateNoteAsync(UpdateNoteDto updateNoteDto, [Service] INoteServiceBLL noteServiceBLL)
        {
            var result = await noteServiceBLL.UpdateAsync(updateNoteDto);
            return result;
        }

        [GraphQLDescription("Delete a Note by ID")]
        public async Task<bool> DeleteNoteAsync(Guid id, [Service] INoteServiceBLL noteServiceBLL)
        {
            var result = await noteServiceBLL.DeleteAsync(id);
            return result;
        }
    }
}
