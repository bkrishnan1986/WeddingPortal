using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Blog.Multicode;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Blog.Multicode
{
    public class CreateMulticodeRequestValidator : AbstractValidator<CreateMulticodeBlogRequest>
    {
        public CreateMulticodeRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
