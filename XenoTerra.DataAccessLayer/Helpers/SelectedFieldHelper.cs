using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Persistence;

namespace XenoTerra.DataAccessLayer.Helpers
{
    public class SelectedFieldHelper
    {
        public static List<string> EnsurePrimaryKeyIncluded<TEntity>(AppDbContext context, IEnumerable<string> selectedFields)
        {
            var fieldList = selectedFields.ToList();

            var entityType = context.Model.FindEntityType(typeof(TEntity))
                              ?? throw new InvalidOperationException($"Entity type '{typeof(TEntity).Name}' not found in DbContext.");

            var primaryKey = entityType.FindPrimaryKey();
            if (primaryKey is null || primaryKey.Properties.Count != 1)
                throw new NotSupportedException($"Entity '{typeof(TEntity).Name}' must define a single primary key.");

            var primaryKeyName = primaryKey.Properties[0].Name;

            if (!fieldList.Contains(primaryKeyName))
            {
                fieldList.Add(primaryKeyName);
            }

            return fieldList;
        }
    }
}
