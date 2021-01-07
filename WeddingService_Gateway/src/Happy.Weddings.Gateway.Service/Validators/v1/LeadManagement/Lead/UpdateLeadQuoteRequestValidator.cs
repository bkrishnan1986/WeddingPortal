using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead;

namespace Happy.Weddings.Gateway.Service.Validators.v1.LeadManagement.Lead
{
    public class UpdateLeadQuoteRequestValidator : AbstractValidator<UpdateLeadQuoteRequest>
    {
        public UpdateLeadQuoteRequestValidator()
        {
            RuleFor(x => x.QuotedRate).NotEmpty();
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
