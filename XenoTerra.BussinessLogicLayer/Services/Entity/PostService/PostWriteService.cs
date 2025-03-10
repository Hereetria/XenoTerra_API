using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Write;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.PostService
{

    public class PostWriteService : WriteService<Post, ResultPostDto, CreatePostDto, UpdatePostDto, Guid>, IPostWriteService
    {
        public PostWriteService(IWriteRepository<Post, Guid> repository, IMapper mapper, SelectorExpressionProvider<Post, ResultPostDto> selectorExpressionProvider)
            : base(repository, mapper, selectorExpressionProvider) { }
    }
}
