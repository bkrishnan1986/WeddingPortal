using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.AuditLog.AuditLog;

namespace Happy.Weddings.Gateway.Service.Validators.v1.AuditLog.AuditLog
{
    public class CreateAuditLogRequestValidator : AbstractValidator<CreateAuditLogRequest>
    {
        public CreateAuditLogRequestValidator()
        {
            RuleFor(x => x.Url).NotEmpty();
            RuleFor(x => x.OldData).NotEmpty();
            RuleFor(x => x.NewData).NotEmpty();
            RuleFor(x => x.ApprovalStatus).NotEmpty();
            RuleFor(x => x.EditedBy).NotEmpty();
        }
    }
}
