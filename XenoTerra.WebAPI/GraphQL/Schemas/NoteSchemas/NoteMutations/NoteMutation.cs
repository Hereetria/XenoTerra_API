using XenoTerra.BussinessLogicLayer.Services.Entity.NoteService;
using XenoTerra.DTOLayer.Dtos.NoteDtos;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.NoteMutations
{
    public class NoteMutation
    {
        [UseProjection]
        [GraphQLDescription("Create a new Note")]
        public async Task<ResultNoteDto> CreateNoteAsync(CreateNoteDto createNoteDto, [Service] INoteWriteService noteWriteService)
        {
            var result = await noteWriteService.CreateAsync(createNoteDto);
            return result;
        }

        [UseProjection]
        [GraphQLDescription("Update an existing Note")]
        public async Task<ResultNoteDto> UpdateNoteAsync(UpdateNoteDto updateNoteDto, [Service] INoteWriteService noteWriteService)
        {
            var result = await noteWriteService.UpdateAsync(updateNoteDto);
            return result;
        }

        [GraphQLDescription("Delete a Note by ID")]
        public async Task<bool> DeleteNoteAsync(Guid id, [Service] INoteWriteService noteWriteService)
        {
            var result = await noteWriteService.DeleteAsync(id);
            return result;
        }
    }
}
