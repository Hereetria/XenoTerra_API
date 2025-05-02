using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Exceptions.Technical;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Repositories.Base.Read;

namespace XenoTerra.BussinessLogicLayer.Helpers
{
    public static class ServiceExceptionHandler
    {
        public static async Task<TEntity> ExecuteWriteSafelyAsync<TEntity>(
            AppDbContext dbContext,
            Func<AppDbContext, Task<TEntity>> operation)
            where TEntity : class
        {
            try
            {
                return await operation(dbContext);
            }
            catch (KeyNotFoundException ex)
            {
                SqlExceptionParser.HandleSqlException<TEntity>(ex, dbContext);
                throw;
            }
            catch (InvalidOperationException ex)
            {
                SqlExceptionParser.HandleSqlException<TEntity>(ex, dbContext);
                throw;
            }
            catch (Exception ex)
            {
                throw new UnexpectedRepositoryException(ex);
            }
        }

        public static IQueryable<TEntity> ExecuteReadSafely<TEntity>(Func<IQueryable<TEntity>> operation)
            where TEntity : class
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                throw new UnexpectedRepositoryException(ex);
            }
        }
    }


}
