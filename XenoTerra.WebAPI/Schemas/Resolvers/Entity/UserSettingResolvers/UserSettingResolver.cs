using AutoMapper;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;
using XenoTerra.WebAPI.Services.Common.DataLoading;
using XenoTerra.WebAPI.Services.Common.EntityMapping;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.UserSettingResolvers
{
    public class UserSettingResolver : EntityResolver<UserSetting, ResultUserSettingWithRelationsDto, Guid>, IUserSettingResolver
    {
        public UserSettingResolver(IEntityFieldMapBuilder<UserSetting, ResultUserSettingWithRelationsDto, Guid> entityFieldMapBuilder, IDataLoaderInvoker dataLoaderInvoker) : base(entityFieldMapBuilder, dataLoaderInvoker)
        {
        }
    }
}
