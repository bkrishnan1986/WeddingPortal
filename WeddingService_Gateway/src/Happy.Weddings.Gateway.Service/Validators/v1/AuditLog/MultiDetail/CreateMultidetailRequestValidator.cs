using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.AuditLog.MultiDetail;

namespace Happy.Weddings.Gateway.Service.Validators.v1.AuditLog.MultiDetail
{
    public class CreateMultidetailRequestValidator : AbstractValidator<CreateMultidetailAuditLogRequest>
    {
        public CreateMultidetailRequestValidator()
        {
            RuleFor(x => x.MultiCodeId).NotEmpty();
            RuleFor(x => x.Value).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
