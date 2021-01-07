using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Blog.Review;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Blog.Review
{
    public class ReviewIdDetailsValidator : AbstractValidator<ReviewIdDetails>
    {
        public ReviewIdDetailsValidator()
        {
            RuleFor(x => x.ReviewId).NotEmpty();
        }
    }
}
