using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.BussinessLogicLayer.Exceptions.Domain;
using XenoTerra.BussinessLogicLayer.Exceptions.Technical;
using XenoTerra.DataAccessLayer.Persistence;

namespace XenoTerra.BussinessLogicLayer.Helpers
{
    public static class SqlExceptionParser
    {
        public static Exception HandleSqlException<TEntity>(
            Exception ex,
            AppDbContext context)
            where TEntity : class
        {
            try
            {
                if (ex.InnerException is not DbUpdateException dbEx ||
                    dbEx.InnerException is not SqlException sqlEx)
                {
                    return ex;
                }

                var entityType = context.Model.FindEntityType(typeof(TEntity));
                if (entityType is null)
                {
                    return ex;
                }

                var foreignKeys = entityType.GetForeignKeys().Concat(entityType.GetReferencingForeignKeys());

                foreach (var fk in foreignKeys)
                {
                    var constraintName = fk.GetConstraintName();
                    if (!string.IsNullOrEmpty(constraintName) &&
                        sqlEx.Message.Contains(constraintName))
                    {
                        string propertyName = fk.Properties[0]?.Name ?? "UnknownProperty";
                        string relatedEntity = fk.PrincipalEntityType?.ClrType?.Name ?? "RelatedEntity";

                        return new ForeignKeyReferenceNotFoundException(propertyName, relatedEntity, ex);
                    }
                }

                return ex;
            }
            catch (Exception handlingEx)
            {
                return new SqlExceptionHandlingFailedException(
                    "An error occurred while analyzing SQL constraint exception.",
                    handlingEx
                );
            }
        }
    }
}
