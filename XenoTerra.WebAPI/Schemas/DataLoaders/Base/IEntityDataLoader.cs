using XenoTerra.DTOLayer.Dtos.UserDtos;

namespace XenoTerra.WebAPI.Schemas.DataLoaders.Base
{
    public interface IEntityDataLoader<TKey, TEntity>
        where TEntity : class
        where TKey : notnull
    {
        Task<IReadOnlyDictionary<TKey, TEntity>> LoadAsync(List<TKey> userIds, List<string> selectedFields);
    }
}
