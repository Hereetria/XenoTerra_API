using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DTOLayer.Dtos.HighlightAdminDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.HighlightServices.Write.Admin
{
    public interface IHighlightAdminWriteService : IWriteService<Highlight, CreateHighlightAdminDto, UpdateHighlightAdminDto, Guid> { }

}
