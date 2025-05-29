using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.WebAPI.GraphQL.DataLoaders.Factories;

namespace XenoTerra.WebAPI.Services.Common.DataLoading
{
    public class DataLoaderInvoker(EntityDataLoaderFactory factory) : IDataLoaderInvoker
    {
        private readonly EntityDataLoaderFactory _factory = factory;

        public async Task<object> InvokeLoadAsync(Type entityType, AppDbContext dbContext, List<object> keys, List<string> selectedFields)
        {
            if (keys == null)
                throw new ArgumentNullException(nameof(keys));

            if (keys.Count == 0)
            {
                // Eğer key yoksa, Dictionary<TKey, TEntity> boş olarak dön
                // TKey'yi bilmediğimiz için varsayılan olarak object alalım (kapsayıcı çözüm)
                var emptyDictType = typeof(Dictionary<,>).MakeGenericType(typeof(object), entityType);
                return Activator.CreateInstance(emptyDictType)!;
            }

            var keyType = keys.First().GetType();

            var getLoaderMethod = typeof(EntityDataLoaderFactory)
                .GetMethod(nameof(EntityDataLoaderFactory.GetDataLoader))
                ?? throw new InvalidOperationException("GetDataLoader not found.");

            var loader = getLoaderMethod.MakeGenericMethod(entityType)
                .Invoke(_factory, null)
                ?? throw new InvalidOperationException("Loader instance is null.");

            var genericKeyListType = typeof(List<>).MakeGenericType(keyType);
            var castedKeys = Activator.CreateInstance(genericKeyListType)!;

            var addMethod = genericKeyListType.GetMethod("Add")!;
            foreach (var key in keys)
            {
                addMethod.Invoke(castedKeys, [key]);
            }

            var loadAsyncMethod = loader.GetType().GetMethod("LoadAsync", [genericKeyListType, typeof(List<string>)])
                ?? throw new InvalidOperationException("LoadAsync method not found.");

            var task = (Task)loadAsyncMethod.Invoke(loader, [castedKeys, selectedFields])!;
            await task.ConfigureAwait(false);

            var resultProp = task.GetType().GetProperty("Result")
                ?? throw new InvalidOperationException("Result property not found.");

            var result = resultProp.GetValue(task);

            if (result == null)
            {
                // Eğer LoadAsync null dönerse, Dictionary<TKey, TEntity> boş olarak dön
                var dictType = typeof(Dictionary<,>).MakeGenericType(keyType, entityType);
                return Activator.CreateInstance(dictType)!;
            }

            return result;
        }
    }

}
