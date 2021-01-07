using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead;

namespace Happy.Weddings.Gateway.Service.Validators.v1.LeadManagement.Lead
{
    public class LeadQuoteIdDetailsValidator : AbstractValidator<LeadQuoteIdDetails>
    {
        public LeadQuoteIdDetailsValidator()
        {
            RuleFor(x => x.LeadQuoteId).NotEmpty();
        }
    }
}
