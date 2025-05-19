using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Read;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.HighlightServices
{
    public class HighlightReadService(IReadRepository<Highlight, Guid> readRepository) : ReadService<Highlight, Guid>(readRepository), IHighlightReadService
    {
    }
}
