using XenoTerra.DataAccessLayer.Persistence;

namespace XenoTerra.WebAPI.Services.Common.DataLoading
{
    public interface IDataLoaderInvoker
    {
        Task<object> InvokeLoadAsync(Type entityType, AppDbContext dbContext, List<object> keys, List<string> selectedFields);
    }
}
