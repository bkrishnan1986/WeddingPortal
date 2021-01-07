using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Identity;
using Happy.Weddings.Gateway.Core.DTO.Identity.Profile;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Identity.User
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserProfileRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
