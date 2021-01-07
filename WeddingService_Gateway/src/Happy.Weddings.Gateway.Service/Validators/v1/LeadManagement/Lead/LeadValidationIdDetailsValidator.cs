using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead;

namespace Happy.Weddings.Gateway.Service.Validators.v1.LeadManagement.Lead
{
    public class LeadValidationIdDetailsValidator : AbstractValidator<LeadValidationIdDetails>
    {
        public LeadValidationIdDetailsValidator()
        {
            RuleFor(x => x.LeadValidationId).NotEmpty();
        }
    }
}
