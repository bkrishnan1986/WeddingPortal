using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead;

namespace Happy.Weddings.Gateway.Service.Validators.v1.LeadManagement.Lead
{
    public class CreateLeadAssignRequestValidator : AbstractValidator<CreateLeadAssignRequest>
    {
        public CreateLeadAssignRequestValidator()
        {
            RuleFor(x => x.VendorId).NotEmpty();
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
