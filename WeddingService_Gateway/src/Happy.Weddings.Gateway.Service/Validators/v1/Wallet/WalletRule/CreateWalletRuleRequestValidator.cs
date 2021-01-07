using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletRule;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Wallet.WalletRule
{
    public class CreateWalletRuleRequestValidator : AbstractValidator<CreateWalletRuleRequest>
    {
        public CreateWalletRuleRequestValidator()
        {
            RuleFor(x => x.ServiceCode).NotEmpty();
            RuleFor(x => x.ServiceCategoryId).NotEmpty();
            RuleFor(x => x.ServiceCategory).NotEmpty();
            RuleFor(x => x.Mode).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
