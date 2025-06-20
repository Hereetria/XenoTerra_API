using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.PostLikeServices.Read
{
    public class PostLikeReadService(IReadRepository<PostLike, Guid> readRepository) : ReadService<PostLike, Guid>(readRepository), IPostLikeReadService
    {
    }
}
