using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XenoTerra.DataAccessLayer.Helpers.Abstract;
using XenoTerra.DTOLayer.Dtos.FollowAdminDtos.Admin;
using XenoTerra.EntityLayer.Entities;

namespace XenoTerra.BussinessLogicLayer.Validators.FollowValidators.Admin
{
    public class CreateFollowAdminDtoValidator : AbstractValidator<CreateFollowAdminDto>
    {
        public CreateFollowAdminDtoValidator(IExistenceChecker<Follow, CreateFollowAdminDto> existenceChecker, IMapper mapper)
        {
            RuleFor(x => x.FollowerId)
                .NotEqual(Guid.Empty)
                .WithMessage("Follower ID is required.");

            RuleFor(x => x.FollowingId)
                .NotEqual(Guid.Empty)
                .WithMessage("Following ID is required.");

            RuleFor(x => x.FollowerId)
                .NotEqual(x => x.FollowingId)
                .WithMessage("A user cannot follow themselves.");

            RuleFor(x => x)
                .MustAsync(async (dto, _) =>
                    !await existenceChecker.ExistsAsync(
                        dto,
                        null,
                        x => x.FollowerId,
                        x => x.FollowingId
                    ))
                .WithMessage("This follow relationship already exists.");
        }
    }
}
