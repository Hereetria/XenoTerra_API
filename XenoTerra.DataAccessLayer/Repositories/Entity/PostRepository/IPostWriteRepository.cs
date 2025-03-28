using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.DataAccessLayer.Repositories.Entity.PostRepository
{
    public interface IPostWriteRepository : IWriteRepository<Post, Guid>
    {
    }
}
