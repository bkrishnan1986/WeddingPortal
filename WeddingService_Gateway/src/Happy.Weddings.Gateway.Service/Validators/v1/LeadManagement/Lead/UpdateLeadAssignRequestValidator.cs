using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead;

namespace Happy.Weddings.Gateway.Service.Validators.v1.LeadManagement.Lead
{
    public class UpdateLeadAssignRequestValidator : AbstractValidator<UpdateLeadAssignRequest>
    {
        public UpdateLeadAssignRequestValidator()
        {
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
