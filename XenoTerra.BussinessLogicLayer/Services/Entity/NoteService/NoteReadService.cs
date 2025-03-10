using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Generic.Read;
using XenoTerra.DataAccessLayer.Repositories.Generic.Read;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.NoteDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.NoteService
{
    public class NoteReadService : ReadService<Note, ResultNoteWithRelationsDto, Guid>, INoteReadService
    {
        public NoteReadService(IReadRepository<Note, Guid> repository, IMapper mapper, SelectorExpressionProvider<Note, ResultNoteWithRelationsDto> selectorExpressionProvider)
            : base(repository, mapper, selectorExpressionProvider) { }
    }
}
