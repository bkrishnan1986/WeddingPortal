using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletDeduction;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Wallet.WalletDeduction
{
    public class WalletDeductionIdDetailsValidator : AbstractValidator<WalletDeductionIdDetails>
    {
        public WalletDeductionIdDetailsValidator()
        {
            RuleFor(x => x.WalletDeductionId).NotEmpty();
        }
    }
}
