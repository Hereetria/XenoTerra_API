using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Services.Base.Write;
using XenoTerra.DataAccessLayer.Repositories.Base.Write;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingService
{
    public class UserSettingWriteService(
            IWriteRepository<UserSetting, Guid> writeRepository,
            IMapper mapper,
            IValidator<CreateUserSettingDto> createValidator,
            IValidator<UpdateUserSettingDto> updateValidator
        )
            : WriteService<UserSetting, CreateUserSettingDto, UpdateUserSettingDto, Guid>(
                writeRepository,
                mapper,
                createValidator,
                updateValidator
            ),
            IUserSettingWriteService
    {
    }
}
