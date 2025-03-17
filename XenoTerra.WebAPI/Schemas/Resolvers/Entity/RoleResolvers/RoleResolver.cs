using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.RoleResolvers
{
    public class RoleResolver : EntityResolver<Role, Guid>, IRoleResolver
    {
        public RoleResolver(EntityDataLoaderFactory entityDataLoaderFactory, IMapper mapper)
            : base(entityDataLoaderFactory, mapper) { }
    }

}
