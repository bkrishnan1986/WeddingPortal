using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Multicode;

namespace Happy.Weddings.Gateway.Service.Validators.v1.LeadManagement.Multicode
{
    public class CreateMulticodeRequestValidator : AbstractValidator<CreateMulticodeLeadRequest>
    {
        public CreateMulticodeRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
