using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Blog.Multidetail;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Blog.Multidetail
{
    public class CreateMultidetailRequestValidator : AbstractValidator<CreateMultidetailBlogRequest>
    {
        public CreateMultidetailRequestValidator()
        {
            RuleFor(x => x.MultiCodeId).NotEmpty();
            RuleFor(x => x.Value).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
