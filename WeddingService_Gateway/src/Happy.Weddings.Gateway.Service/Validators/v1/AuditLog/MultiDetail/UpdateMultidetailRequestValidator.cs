using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.AuditLog.MultiDetail;

namespace Happy.Weddings.Gateway.Service.Validators.v1.AuditLog.MultiDetail
{
    public class UpdateMultidetailRequestValidator : AbstractValidator<UpdateMultidetailAuditLogRequest>
    {
        public UpdateMultidetailRequestValidator()
        {
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
