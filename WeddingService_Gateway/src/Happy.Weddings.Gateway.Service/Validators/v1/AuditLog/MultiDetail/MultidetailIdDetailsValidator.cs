using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.AuditLog.MultiDetail;

namespace Happy.Weddings.Gateway.Service.Validators.v1.AuditLog.MultiDetail
{
    public class MultidetailIdDetailsValidator : AbstractValidator<MultidetailIdDetails>
    {
        public MultidetailIdDetailsValidator()
        {
            RuleFor(x => x.MultidetailId).NotEmpty();
        }
    }
}
