using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Persistence;

namespace XenoTerra.DataAccessLayer.Helpers
{
    public static class RepositoryExceptionHandler
    {
        public static TResult ExecuteReadSafely<TResult>(Func<TResult> query)
        {
            try
            {
                return query();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new InvalidOperationException("A concurrency conflict occurred during data access.", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException("An invalid operation was attempted during query execution.", ex);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("An invalid argument was provided to the query.", ex);
            }
            catch (TimeoutException ex)
            {
                throw new TimeoutException("The query has timed out while accessing the database.", ex);
            }
            catch (SqlException ex)
            {
                throw new InvalidOperationException("A SQL error occurred while executing the query.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while executing the query.", ex);
            }
        }

        public static async Task<TEntity> ExecuteWriteSafelyAsync<TEntity>(
            Func<Task<TEntity>> operation,
            Func<Task> rollback,
            string operationName)
        {
            try
            {
                return await operation();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await rollback();
                throw new InvalidOperationException("A concurrency conflict occurred during data operation.", ex);
            }
            catch (DbUpdateException ex)
            {
                await rollback();
                throw new InvalidOperationException("A database update error occurred.", ex);
            }
            catch (ArgumentException ex)
            {
                await rollback();
                throw new ArgumentException("Invalid argument provided to the operation.", ex);
            }
            catch (TimeoutException ex)
            {
                await rollback();
                throw new TimeoutException("The operation timed out while writing to the database.", ex);
            }
            catch (Exception ex)
            {
                await rollback();
                throw new Exception($"An unexpected error occurred while {operationName} the entity.", ex);
            }
        }
    }
}
