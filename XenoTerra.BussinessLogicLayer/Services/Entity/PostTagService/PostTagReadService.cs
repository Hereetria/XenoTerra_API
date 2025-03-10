using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.PostTagDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.PostTagService
{
    public class PostTagReadService : ReadService<PostTag, ResultPostTagWithRelationsDto, Guid>, IPostTagReadService
    {
        public PostTagReadService(IReadRepository<PostTag, Guid> repository, IMapper mapper, SelectorExpressionProvider<PostTag, ResultPostTagWithRelationsDto> selectorExpressionProvider)
            : base(repository, mapper, selectorExpressionProvider) { }
    }

}
