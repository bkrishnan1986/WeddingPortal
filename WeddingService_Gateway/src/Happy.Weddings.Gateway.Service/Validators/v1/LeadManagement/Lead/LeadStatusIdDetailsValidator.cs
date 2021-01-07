using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead;

namespace Happy.Weddings.Gateway.Service.Validators.v1.LeadManagement.Lead
{
    public class LeadStatusIdDetailsValidator : AbstractValidator<LeadStatusIdDetails>
    {
        public LeadStatusIdDetailsValidator()
        {
            RuleFor(x => x.LeadStatusId).NotEmpty();
        }
    }
}
