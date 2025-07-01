using XenoTerra.DTOLayer.Dtos.PostDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Services.Mutations.Base;

namespace XenoTerra.WebAPI.Services.Mutations.Entity.Self.PostMutationServices
{
    public interface IPostOwnMutationService : IMutationService<Post, ResultPostOwnDto, CreatePostOwnDto, UpdatePostOwnDto, Guid>
    {
    }
}
