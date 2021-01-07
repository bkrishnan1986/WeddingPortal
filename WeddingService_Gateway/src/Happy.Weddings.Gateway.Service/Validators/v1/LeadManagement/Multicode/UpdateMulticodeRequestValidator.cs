using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.LeadManagement.Multicode;

namespace Happy.Weddings.Gateway.Service.Validators.v1.LeadManagement.Multicode
{
    public class UpdateMulticodeRequestValidator : AbstractValidator<UpdateMulticodeLeadRequest>
    {
        public UpdateMulticodeRequestValidator()
        {
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
