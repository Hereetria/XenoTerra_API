using XenoTerra.DataAccessLayer.Contexts;
using XenoTerra.WebAPI.Schemas.DataLoaders.DataLoaderFactories;

namespace XenoTerra.WebAPI.Services.Common.DataLoading
{
    public class DataLoaderInvoker : IDataLoaderInvoker
    {
        private readonly EntityDataLoaderFactory _factory;

        public DataLoaderInvoker(EntityDataLoaderFactory factory)
        {
            _factory = factory;
        }

        public async Task<object> InvokeLoadAsync(Type entityType, AppDbContext dbContext, List<object> keys, List<string> selectedFields)
        {
            if (keys == null || keys.Count == 0)
                throw new ArgumentException("Keys list cannot be null or empty.", nameof(keys));

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
                addMethod.Invoke(castedKeys, new[] { key });
            }

            var loadAsyncMethod = loader.GetType().GetMethod("LoadAsync", new[] { genericKeyListType, typeof(List<string>) })
                ?? throw new InvalidOperationException("LoadAsync method not found.");

            var task = (Task)loadAsyncMethod.Invoke(loader, new object[] { castedKeys, selectedFields })!;
            await task.ConfigureAwait(false);

            var resultProp = task.GetType().GetProperty("Result")
                ?? throw new InvalidOperationException("Result property not found.");

            return resultProp.GetValue(task)
                ?? throw new InvalidOperationException("LoadAsync returned null.");
        }

    }

}
