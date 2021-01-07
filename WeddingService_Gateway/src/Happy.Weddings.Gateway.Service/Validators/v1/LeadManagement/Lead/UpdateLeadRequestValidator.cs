using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead;

namespace Happy.Weddings.Gateway.Service.Validators.v1.LeadManagement.Lead
{
    public class UpdateLeadRequestValidator : AbstractValidator<UpdateLeadRequest>
    {
        public UpdateLeadRequestValidator()
        {
            RuleFor(x => x.LeadType).NotEmpty();
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.EventType).NotEmpty();
            RuleFor(x => x.LeadStatusId).NotEmpty();
            RuleFor(x => x.LeadMode).NotEmpty();
            RuleFor(x => x.LeadQuality).NotEmpty();
            RuleFor(x => x.WalletStatus).NotEmpty();
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
