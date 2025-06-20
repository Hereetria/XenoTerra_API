using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Self.Own;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.HighlightServices.Write.Own
{
    public interface IHighlightOwnWriteService : IWriteService<Highlight, CreateHighlightOwnDto, UpdateHighlightOwnDto, Guid> { }

}
