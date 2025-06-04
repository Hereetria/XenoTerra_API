using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.DTOLayer.Dtos.HighlightDtos;
using XenoTerra.DTOLayer.Dtos.AppRoleDtos;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.AppRoleServices
{
    public interface IAppRoleWriteService
    {
        Task<AppRole> CreateAsync(CreateAppRoleDto dto);
        Task<AppRole> UpdateAsync(UpdateAppRoleDto dto, IEnumerable<string> modifiedFields);
        Task<AppRole> DeleteAsync(Guid id);
    }
}
