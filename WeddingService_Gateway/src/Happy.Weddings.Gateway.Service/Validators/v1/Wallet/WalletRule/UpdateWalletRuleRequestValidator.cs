using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletRule;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Wallet.WalletRule
{
    public class UpdateWalletRuleRequestValidator : AbstractValidator<UpdateWalletRuleRequest>
    {
        public UpdateWalletRuleRequestValidator()
        {
            RuleFor(x => x.Mode).NotEmpty();
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
