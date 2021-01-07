using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead;

namespace Happy.Weddings.Gateway.Service.Validators.v1.LeadManagement.Lead
{
    public class UpdateLeadStatusRequestValidator : AbstractValidator<UpdateLeadStatusRequest>
    {
        public UpdateLeadStatusRequestValidator()
        {
            RuleFor(x => x.LeadStatusId).NotEmpty();
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
