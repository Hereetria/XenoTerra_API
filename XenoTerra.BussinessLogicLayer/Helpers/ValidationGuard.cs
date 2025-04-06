using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XenoTerra.BussinessLogicLayer.Helpers
{
    public static class ValidationGuard
    {
        public static async Task ValidateOrThrowAsync<TDto>(IValidator<TDto> validator, TDto dto)
            where TDto : class
        {
            ValidationResult result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
                throw new ValidationException(result.Errors);
        }
    }
}
