using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Blog.Multidetail;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Blog.Multidetail
{
    public class UpdateMultidetailRequestValidator : AbstractValidator<UpdateMultidetailBlogRequest>
    {
        public UpdateMultidetailRequestValidator()
        {
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
