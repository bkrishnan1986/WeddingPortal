using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead;

namespace Happy.Weddings.Gateway.Service.Validators.v1.LeadManagement.Lead
{
    public class UpdateLeadValidationRequestValidator : AbstractValidator<UpdateLeadValidationRequest>
    {
        public UpdateLeadValidationRequestValidator()
        {
            RuleFor(x => x.Status).NotEmpty();
            RuleFor(x => x.Remark).NotEmpty();
            RuleFor(x => x.FollowUpDate).NotEmpty();
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
