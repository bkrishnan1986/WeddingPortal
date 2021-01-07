using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.AuditLog.AuditLog;

namespace Happy.Weddings.Gateway.Service.Validators.v1.AuditLog.AuditLog
{
    public class AuditLogIdDetailsValidator : AbstractValidator<AuditLogIdDetails>
    {
        public AuditLogIdDetailsValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
