using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Wallet.Refund;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Wallet.Refund
{
    public class CreateRefundRequestValidator : AbstractValidator<CreateRefundRequest>
    {
        public CreateRefundRequestValidator()
        {
            RuleFor(x => x.Activity).NotEmpty();
            RuleFor(x => x.RaisedDate).NotEmpty();
            RuleFor(x => x.RaisedBy).NotEmpty();
            RuleFor(x => x.RefundType).NotEmpty();
            RuleFor(x => x.RefundAmount).NotEmpty();
            RuleFor(x => x.RefundReason).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
