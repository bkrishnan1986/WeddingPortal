using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead;

namespace Happy.Weddings.Gateway.Service.Validators.v1.LeadManagement.Lead
{
    public class LeadDataCollectionIdDetailsValidator : AbstractValidator<LeadDataCollectionIdDetails>
    {
        public LeadDataCollectionIdDetailsValidator()
        {
            RuleFor(x => x.LeadCollectionId).NotEmpty();
        }
    }
}
