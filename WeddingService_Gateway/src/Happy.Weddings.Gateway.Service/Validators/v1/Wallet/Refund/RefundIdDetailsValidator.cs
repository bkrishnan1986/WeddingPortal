using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Wallet.Refund;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Wallet.Refund
{
    public class RefundIdDetailsValidator : AbstractValidator<RefundIdDetails>
    {
        public RefundIdDetailsValidator()
        {
            RuleFor(x => x.RefundId).NotEmpty();
        }
    }
}
