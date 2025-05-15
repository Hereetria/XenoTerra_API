using FluentValidation;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.Helpers;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Mutations.Validators
{
    public class UpdateUserInputValidator : AbstractValidator<UpdateUserInput>
    {
        public UpdateUserInputValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id must not be empty.")
                .Must(ValidationHelper.BeValidGuid).WithMessage("Id must be a valid GUID.");

            When(x => x.BirthDate is not null, () =>
            {
                RuleFor(x => x.BirthDate)
                    .Must(ValidationHelper.BeValidDate).WithMessage("BirthDate must be a valid date.")
                    .Must(ValidationHelper.BeInPast).WithMessage("BirthDate cannot be in the future.");
            });

            When(x => x.LastActive is not null, () =>
            {
                RuleFor(x => x.LastActive)
                    .Must(ValidationHelper.BeValidDate).WithMessage("LastActive must be a valid date.")
                    .Must(ValidationHelper.BeInPast).WithMessage("LastActive cannot be in the future.");
            });

            When(x => x.FollowersCount is not null, () =>
            {
                RuleFor(x => x.FollowersCount!.Value)
                    .GreaterThanOrEqualTo(0).WithMessage("FollowersCount cannot be negative.");
            });

            When(x => x.FollowingCount is not null, () =>
            {
                RuleFor(x => x.FollowingCount!.Value)
                    .GreaterThanOrEqualTo(0).WithMessage("FollowingCount cannot be negative.");
            });
        }
    }
}
