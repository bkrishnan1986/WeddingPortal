using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.AuditLog.MultiCode;

namespace Happy.Weddings.Gateway.Service.Validators.v1.AuditLog.MultiCode
{
    public class UpdateMulticodeRequestValidator : AbstractValidator<UpdateMulticodeAuditLogRequest>
    {
        public UpdateMulticodeRequestValidator()
        {
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
