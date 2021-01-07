using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletDeduction;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Wallet.WalletDeduction
{
    public class UpdateWalletDeductionRequestValidator : AbstractValidator<UpdateWalletDeductionRequest>
    {
        public UpdateWalletDeductionRequestValidator()
        {
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
