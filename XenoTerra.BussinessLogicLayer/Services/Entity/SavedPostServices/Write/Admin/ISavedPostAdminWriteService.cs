using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos.Admin;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.SavedPostServices.Write.Admin
{
    public interface ISavedPostAdminWriteService : IWriteService<SavedPost, CreateSavedPostAdminDto, UpdateSavedPostAdminDto, Guid> { }

}
