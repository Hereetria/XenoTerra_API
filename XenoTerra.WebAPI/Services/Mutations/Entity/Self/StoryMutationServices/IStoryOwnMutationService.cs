using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DTOLayer.Dtos.StoryDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.StoryMutationServices
{
    public interface IStoryOwnMutationService
    {
        Task<CreateStoryOwnPayload> CreateAsync(CreateStoryOwnDto dto);
        Task<DeleteStoryOwnPayload> DeleteAsync(Guid key);
    }
}
