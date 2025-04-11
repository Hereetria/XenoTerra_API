using HotChocolate.Execution.Processing;
using HotChocolate.Resolvers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using XenoTerra.DataAccessLayer.Persistence;
using XenoTerra.DataAccessLayer.Utils;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Attributes;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Payloads;

namespace XenoTerra.WebAPI.Utils
{
    public static class InputValidator
    {
        public static bool ValidateGuidInput<TEntity, TResultDto, TPayload>(
            [NotNullWhen(true)] string? value,
            IResolverContext context,
            out TPayload payload)
            where TEntity : class
            where TResultDto : class
            where TPayload : Payload<TResultDto>, new()
        {
            var dbContext = context.Service<AppDbContext>();
            var fieldName = TypeProviders.GetPrimaryKeyProperty<TEntity>(dbContext).Name;
            if (string.IsNullOrWhiteSpace(value))
            {
                payload = Payload<TResultDto>.FromFailure<TPayload>(
                    "Input is required.",
                    [$"{fieldName} is required."]
                );
                return false;
            }

            if (!Guid.TryParse(value, out _))
            {
                payload = Payload<TResultDto>.FromFailure<TPayload>(
                    "Invalid GUID format.",
                    [$"{fieldName} must be a valid GUID."]
                );
                return false;
            }

            payload = Payload<TResultDto>.FromSuccess<TPayload>("Valid", null!);
            return true;
        }

        public static bool ValidateGuidListInput<TEntity, TResultDto, TPayload>(
            [NotNullWhen(true)] IEnumerable<string>? values,
            IResolverContext context,
            TPayload payload)
            where TEntity : class
            where TResultDto : class
            where TPayload : Payload<TResultDto>, new()
        {
            var dbContext = context.Service<AppDbContext>();
            var fieldName = TypeProviders.GetPrimaryKeyProperty<TEntity>(dbContext).Name;

            if (values is null || !values.Any())
            {
                payload = Payload<TResultDto>.FromFailure<TPayload>(
                    "Input is required.",
                    [$"{fieldName} list is required."]
                );
                return false;
            }

            var invalidValues = values
                .Where(v => !Guid.TryParse(v, out _))
                .ToList();

            if (invalidValues.Count != 0)
            {
                var errorList = invalidValues.Select(v => $"{fieldName} '{v}' is not a valid GUID.").ToList();
                payload = Payload<TResultDto>.FromFailure<TPayload>(
                    "One or more IDs are invalid.",
                    errorList
                );
                return false;
            }

            payload = Payload<TResultDto>.FromSuccess<TPayload>("Valid", null!);
            return true;
        }


        public static bool ValidateInputFields<TEntity, TInput, TResultDto, TPayload>(
            [NotNullWhen(true)] TInput? input,
            IResolverContext context,
            out TPayload payload)
            where TEntity : class
            where TInput : class
            where TResultDto : class
            where TPayload : Payload<TResultDto>, new()
        {
            var schema = context.Schema;
            IEnumerable<string> selectedInputFields = GraphQLFieldProvider.GetSelectedParameterFields<TInput>(context, nameof(input));
            IEnumerable<string> idFieldNames = GraphQLFieldProvider.GetIdFieldNamesFromInputType<TInput>(schema);
            IEnumerable<string> dateFieldNames = GraphQLFieldProvider.GetFieldNamesByAttribute<TInput, DateFieldAttribute>();

            var errors = new List<string>();
            var inputName = typeof(TInput).Name;

            if (input is null)
            {
                errors.Add($"{inputName} is required.");
                payload = Payload<TResultDto>.FromFailure<TPayload>("Input cannot be null.", errors);
                return false;
            }

            var type = typeof(TInput);

            var dbContext = context.Service<AppDbContext>();
            var primaryKeyName = TypeProviders.GetPrimaryKeyProperty<TEntity>(dbContext).Name;

            idFieldNames = idFieldNames
                .Where(field => selectedInputFields.Contains(field, StringComparer.OrdinalIgnoreCase))
                .Where(field => !string.Equals(field, primaryKeyName, StringComparison.OrdinalIgnoreCase));

            dateFieldNames = dateFieldNames
                .Where(field => selectedInputFields.Contains(field, StringComparer.OrdinalIgnoreCase));

            foreach (var fieldName in idFieldNames)
            {
                var prop = GetProperty(type, fieldName, inputName, errors);
                if (prop is null) continue;

                var value = prop.GetValue(input) as string;

                if (!IsValidGuid(value))
                    errors.Add($"{fieldName} cannot convert to Guid.");
            }

            foreach (var fieldName in dateFieldNames)
            {
                var prop = GetProperty(type, fieldName, inputName, errors);
                if (prop is null) continue;

                var value = prop.GetValue(input) as string;

                if (!IsValidDateTime(value))
                    errors.Add($"{fieldName} cannot convert to DateTime.");
            }

            if (errors.Count > 0)
            {
                payload = Payload<TResultDto>.FromFailure<TPayload>("Invalid input format.", errors);
                return false;
            }

            payload = Payload<TResultDto>.FromSuccess<TPayload>("Valid");
            return true;
        }




        private static PropertyInfo? GetProperty(Type type, string fieldName, string inputName, List<string> errors)
        {
            var prop = type.GetProperty(
                fieldName,
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase
            );

            if (prop is null)
                errors.Add($"{fieldName} does not exist on '{inputName}'.");

            return prop;
        }

        private static bool IsValidGuid(string? value)
        {
            return Guid.TryParse(value, out _);
        }

        private static bool IsValidDateTime(string? value)
        {
            return !string.IsNullOrWhiteSpace(value) && DateTime.TryParse(value, out _);
        }
    }
}
