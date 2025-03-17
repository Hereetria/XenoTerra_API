using AutoMapper;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;
using XenoTerra.WebAPI.Schemas.Resolvers.Base;

namespace XenoTerra.WebAPI.Schemas.Resolvers.EntityResolvers.MessageResolvers
{

    public class MessageResolver : EntityResolver<Message, Guid>, IMessageResolver
    {
        public MessageResolver(EntityDataLoaderFactory entityDataLoaderFactory, IMapper mapper)
            : base(entityDataLoaderFactory, mapper) { }
    }
}
