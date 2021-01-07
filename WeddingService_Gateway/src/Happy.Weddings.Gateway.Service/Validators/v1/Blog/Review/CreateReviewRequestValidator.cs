using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Blog.Review;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Blog.Review
{
    public class CreateReviewRequestValidator : AbstractValidator<CreateReviewBlogRequest>
    {
        public CreateReviewRequestValidator()
        {
            RuleFor(x => x.ReferenceId).NotEmpty();
            RuleFor(x => x.ReviewType).NotEmpty();
            RuleFor(x => x.Rating).NotEmpty();
            RuleFor(x => x.ReviewedBy).NotEmpty();
            RuleFor(x => x.ApprovalStatus).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
