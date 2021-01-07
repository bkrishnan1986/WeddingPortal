using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletAdjustment;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Wallet.WalletAdjustment
{
    public class WalletAdjustmentIdDetailsValidator : AbstractValidator<WalletAdjustmentIdDetails>
    {
        public WalletAdjustmentIdDetailsValidator()
        {
            RuleFor(x => x.WalletAdjustmentId).NotEmpty();
        }
    }
}
