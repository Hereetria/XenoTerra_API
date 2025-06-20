using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.CommentLikeAdminDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.CommentLikeValidators.Admin
{
    public class CreateCommentLikeAdminDtoValidator : AbstractValidator<CreateCommentLikeAdminDto>
    {
        public CreateCommentLikeAdminDtoValidator(IExistenceChecker<CommentLike, CreateCommentLikeAdminDto> existenceChecker)
        {
            RuleFor(x => x.CommentId)
                .NotEqual(Guid.Empty)
                .WithMessage("Comment ID is required.");

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .WithMessage("User ID is required.");

            RuleFor(x => x.LikedAt)
                .LessThanOrEqualTo(DateTime.Today.AddDays(1))
                .WithMessage("Liked time cannot be in the future.");

            RuleFor(x => x)
                .MustAsync(async (dto, cancellation) =>
                    !await existenceChecker.ExistsAsync(dto, null, x => x.CommentId, x => x.UserId))
                .WithMessage("This comment like already exists.");
        }
    }
}
