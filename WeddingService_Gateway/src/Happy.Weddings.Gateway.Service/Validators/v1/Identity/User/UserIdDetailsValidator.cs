using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Identity;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Identity.User
{
    public class UserIdDetailsValidator : AbstractValidator<ProfileIdDetails>
    {
        public UserIdDetailsValidator()
        {
            RuleFor(x => x.ProfileId).NotEmpty();
        }
    }
}
