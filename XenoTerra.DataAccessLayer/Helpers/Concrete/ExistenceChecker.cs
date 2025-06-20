using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DataAccessLayer.Persistence;

namespace XenoTerra.DataAccessLayer.Helpers.Concrete
{
    public class ExistenceChecker<TEntity, TDto>(AppDbContext dbContext, IMapper mapper) : IExistenceChecker<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        private readonly AppDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public async Task<bool> ExistsAsync(
            TDto dto,
            Expression<Func<TEntity, object>>? excludeIdExpression = null,
            params Expression<Func<TEntity, object>>[] matchExpressions)
        {
            ArgumentGuard.EnsureNotNull(dto);
            if (matchExpressions is null || matchExpressions.Length == 0)
                throw new ArgumentException("At least one match field must be provided.", nameof(matchExpressions));

            var entity = _mapper.Map<TEntity>(dto);

            if (excludeIdExpression is not null)
            {
                var excludeProp = GetPropertyName(excludeIdExpression);
                var excludeValue = GetPropertyValue(entity, excludeProp);

                if (excludeValue is null)
                {
                    var dtoPkValue = GetPropertyValue(dto, excludeProp);
                    if (dtoPkValue is null)
                        throw new ArgumentException($"Primary key value '{excludeProp}' could not be retrieved.");

                    var existing = await _dbContext.Set<TEntity>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => EF.Property<object>(e, excludeProp).Equals(dtoPkValue));

                    if (existing is not null)
                    {
                        var pkVal = GetPropertyValue(existing, excludeProp);
                        SetPropertyValue(entity, excludeProp, pkVal);
                    }
                }
            }

            var parameter = Expression.Parameter(typeof(TEntity), "e");
            Expression? predicateBody = null;

            foreach (var expr in matchExpressions)
            {
                var name = GetPropertyName(expr);
                var value = GetPropertyValue(entity, name);
                if (value is null)
                    throw new ArgumentException($"Mapped field '{name}' is null.");

                var property = Expression.Property(parameter, name);
                var constant = Expression.Constant(value, value.GetType());
                var equal = Expression.Equal(property, constant);

                predicateBody = predicateBody is null ? equal : Expression.AndAlso(predicateBody, equal);
            }

            if (excludeIdExpression is not null)
            {
                var name = GetPropertyName(excludeIdExpression);
                var value = GetPropertyValue(entity, name);
                if (value is null)
                    throw new ArgumentException($"Exclude field '{name}' could not be resolved.");

                var property = Expression.Property(parameter, name);
                var constant = Expression.Constant(value, value.GetType());
                var notEqual = Expression.NotEqual(property, constant);

                predicateBody = Expression.AndAlso(predicateBody!, notEqual);
            }

            if (predicateBody is null)
                throw new InvalidOperationException("Predicate construction failed.");

            var predicate = Expression.Lambda<Func<TEntity, bool>>(predicateBody, parameter);
            return await _dbContext.Set<TEntity>().AsNoTracking().AnyAsync(predicate);
        }

        private static string GetPropertyName(Expression expression)
        {
            if (expression is LambdaExpression lambda)
            {
                if (lambda.Body is UnaryExpression unary && unary.Operand is MemberExpression member1)
                    return member1.Member.Name;

                if (lambda.Body is MemberExpression member2)
                    return member2.Member.Name;
            }

            throw new ArgumentException("Invalid expression.");
        }

        private static object? GetPropertyValue(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName)?.GetValue(obj);
        }

        private static void SetPropertyValue(object obj, string propertyName, object? value)
        {
            obj.GetType().GetProperty(propertyName)?.SetValue(obj, value);
        }
    }
}
