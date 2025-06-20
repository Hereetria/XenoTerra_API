using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.CommentValidators.Admin
{
    public class UpdateCommentAdminDtoValidator : AbstractValidator<UpdateCommentAdminDto>
    {
        public UpdateCommentAdminDtoValidator(IExistenceChecker<Comment, UpdateCommentAdminDto> existenceChecker, IMapper mapper)
        {
            RuleFor(x => x.CommentId)
                .NotEqual(Guid.Empty)
                .WithMessage("Comment ID is required.");

            RuleFor(x => x.Content)
                .NotEmpty()
                .When(x => x.Content is not null)
                .WithMessage("Content cannot be empty.");

            RuleFor(x => x.PostId)
                .NotEqual(Guid.Empty)
                .When(x => x.PostId.HasValue)
                .WithMessage("Post ID cannot be empty.");

            RuleFor(x => x.UserId)
                .NotEqual(Guid.Empty)
                .When(x => x.UserId.HasValue)
                .WithMessage("User ID cannot be empty.");

            RuleFor(x => x.ParentCommentId)
                .NotEqual(Guid.Empty)
                .When(x => x.ParentCommentId.HasValue)
                .WithMessage("Parent comment ID cannot be empty.");
        }
    }

}
