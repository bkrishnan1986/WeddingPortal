using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Identity;
using Happy.Weddings.Gateway.Core.DTO.Identity.Profile;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Identity.User
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserProfileRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
