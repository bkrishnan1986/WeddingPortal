using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Lead;

namespace Happy.Weddings.Gateway.Service.Validators.v1.LeadManagement.Lead
{
    public class CreateLeadDataCollectionRequestValidator : AbstractValidator<CreateLeadDataCollectionRequest>
    {
        public CreateLeadDataCollectionRequestValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty();
            RuleFor(x => x.CustomerEmail).NotEmpty();
            RuleFor(x => x.CustomerPhone1).NotEmpty();
            RuleFor(x => x.CustomerLocation).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
