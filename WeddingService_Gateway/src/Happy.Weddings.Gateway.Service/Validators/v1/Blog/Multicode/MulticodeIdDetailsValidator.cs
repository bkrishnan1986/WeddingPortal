using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Blog.Multicode;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Blog.Multicode
{
    public class MulticodeIdDetailsValidator : AbstractValidator<MulticodeIdDetails>
    {
        public MulticodeIdDetailsValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}
