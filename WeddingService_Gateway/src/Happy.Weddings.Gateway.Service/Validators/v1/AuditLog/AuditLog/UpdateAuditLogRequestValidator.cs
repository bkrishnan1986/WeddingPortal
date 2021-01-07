using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.AuditLog.AuditLog;

namespace Happy.Weddings.Gateway.Service.Validators.v1.AuditLog.AuditLog
{
    public class UpdateAuditLogRequestValidator : AbstractValidator<UpdateAuditLogRequest>
    {
        public UpdateAuditLogRequestValidator()
        {
            RuleFor(x => x.ApprovalStatus).NotEmpty();
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
