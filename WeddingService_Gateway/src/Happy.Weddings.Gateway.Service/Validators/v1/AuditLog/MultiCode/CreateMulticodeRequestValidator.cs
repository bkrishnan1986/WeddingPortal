using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.AuditLog.MultiCode;

namespace Happy.Weddings.Gateway.Service.Validators.v1.AuditLog.MultiCode
{
    public class CreateMulticodeRequestValidator : AbstractValidator<CreateMulticodeAuditLogRequest>
    {
        public CreateMulticodeRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
