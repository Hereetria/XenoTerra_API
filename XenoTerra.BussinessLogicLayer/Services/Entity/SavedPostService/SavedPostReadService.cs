using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SavedPostService
{
    public class SavedPostReadService : ReadService<SavedPost, ResultSavedPostWithRelationsDto, Guid>, ISavedPostReadService
    {
        public SavedPostReadService(IReadRepository<SavedPost, Guid> repository, IMapper mapper, SelectorExpressionProvider<SavedPost, ResultSavedPostWithRelationsDto> selectorExpressionProvider)
            : base(repository, mapper, selectorExpressionProvider) { }
    }
}
