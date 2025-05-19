using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.PostDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.PostServices
{
    public interface IPostReadService : IReadService<Post, Guid> { }

}
