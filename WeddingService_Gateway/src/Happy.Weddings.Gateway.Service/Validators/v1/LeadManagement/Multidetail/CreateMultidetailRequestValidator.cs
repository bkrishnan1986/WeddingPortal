using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Multidetail;

namespace Happy.Weddings.Gateway.Service.Validators.v1.LeadManagement.Multidetail
{
    public class CreateMultidetailRequestValidator : AbstractValidator<CreateMultidetailLeadRequest>
    {
        public CreateMultidetailRequestValidator()
        {
            RuleFor(x => x.MultiCodeId).NotEmpty();
            RuleFor(x => x.Value).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
