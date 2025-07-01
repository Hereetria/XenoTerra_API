using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos.Self.Own;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SavedPostServices.Write.Own
{
    public interface ISavedPostOwnWriteService : IWriteService<SavedPost, CreateSavedPostOwnDto, UpdateSavedPostOwnDto, Guid> { }

}
