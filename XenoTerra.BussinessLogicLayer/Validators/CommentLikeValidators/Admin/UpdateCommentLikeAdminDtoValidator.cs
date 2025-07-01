using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.CommentLikeValidators.Admin
{
    public class UpdateCommentLikeAdminDtoValidator : AbstractValidator<UpdateCommentLikeAdminDto>
    {
        public UpdateCommentLikeAdminDtoValidator(IExistenceChecker<CommentLike, UpdateCommentLikeAdminDto> existenceChecker)
        {
            RuleFor(x => x.CommentLikeId)
                .NotEqual(Guid.Empty)
                .WithMessage("Comment like ID is required.");

            RuleFor(x => x.CommentId)
                .NotEqual(Guid.Empty)
                .When(x => x.CommentId.HasValue)
                .WithMessage("Comment ID cannot be empty.");

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .When(x => x.UserId.HasValue)
                .WithMessage("User ID cannot be empty.");

            RuleFor(x => x)
                .MustAsync(async (dto, _) =>
                    !await existenceChecker.ExistsAsync(
                        dto,
                        x => x.CommentLikeId,
                        x => x.CommentId,
                        x => x.UserId
                    ))
                .WithMessage("This comment like already exists.");
        }
    }
}
