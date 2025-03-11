using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Write;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.PostTagDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.PostTagService
{
    public class PostTagWriteService : WriteService<PostTag, ResultPostTagDto, CreatePostTagDto, UpdatePostTagDto, Guid>, IPostTagWriteService
    {
        public PostTagWriteService(IWriteRepository<PostTag, Guid> repository, IMapper mapper)
            : base(repository, mapper) { }
    }

}
