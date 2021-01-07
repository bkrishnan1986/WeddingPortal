using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Blog.Story;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Blog.Story
{
    public class UpdateStoryRequestValidator : AbstractValidator<UpdateStoryRequest>
    {
        public UpdateStoryRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.EventType).NotEmpty();
            RuleFor(x => x.ServiceId).NotEmpty();
            RuleFor(x => x.VendorId).NotEmpty();
            RuleFor(x => x.ApprovalStatus).NotEmpty();
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
