using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.BussinessLogicLayer.Helpers
{
    public static class PatchMapper
    {
        public static void ApplyPatch<TDto, TEntity>(TDto dto, TEntity entity)
            where TDto : class
            where TEntity : class
        {
            var dtoProps = typeof(TDto).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var entityProps = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                              .ToDictionary(p => p.Name);

            foreach (var dtoProp in dtoProps)
            {
                var value = dtoProp.GetValue(dto);
                if (value is null) continue;

                if (entityProps.TryGetValue(dtoProp.Name, out var entityProp))
                {
                    if (entityProp.CanWrite && entityProp.PropertyType.IsAssignableFrom(dtoProp.PropertyType))
                    {
                        entityProp.SetValue(entity, value);
                    }
                }
            }
        }
    }
}
