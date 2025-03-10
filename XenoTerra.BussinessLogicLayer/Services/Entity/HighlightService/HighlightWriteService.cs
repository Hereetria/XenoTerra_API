using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Write;
using XenoTerra.DataAccessLayer.Repositories.Generic.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.HighlightService
{
    public class HighlightWriteService : WriteService<Highlight, ResultHighlightDto, CreateHighlightDto, UpdateHighlightDto, Guid>, IHighlightWriteService
    {
        public HighlightWriteService(IWriteRepository<Highlight, Guid> repository, IMapper mapper, SelectorExpressionProvider<Highlight, ResultHighlightDto> selectorExpressionProvider)
            : base(repository, mapper, selectorExpressionProvider) { }
    }
}
