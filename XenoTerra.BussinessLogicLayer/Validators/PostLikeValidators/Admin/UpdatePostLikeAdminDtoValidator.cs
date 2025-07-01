using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.PostLikeValidators.Admin
{
    public class UpdatePostLikeAdminDtoValidator : AbstractValidator<UpdatePostLikeAdminDto>
    {
        public UpdatePostLikeAdminDtoValidator(IExistenceChecker<PostLike, UpdatePostLikeAdminDto> existenceChecker)
        {
            RuleFor(x => x.PostLikeId)
                .NotEqual(Guid.Empty)
                .WithMessage("PostLike ID is required.");

            RuleFor(x => x.PostId)
                .NotEqual(Guid.Empty)
                .When(x => x.PostId.HasValue)
                .WithMessage("Post ID cannot be empty.");

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .When(x => x.UserId.HasValue)
                .WithMessage("User ID cannot be empty.");

            RuleFor(x => x)
                .MustAsync(async (dto, _) =>
                {
                    return !await existenceChecker.ExistsAsync(
                        dto,
                        x => x.PostLikeId,
                        x => x.PostId,
                        x => x.UserId
                    );
                })
                .WithMessage("This post like already exists.");
        }
    }
}
