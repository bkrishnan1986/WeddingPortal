using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletDeduction;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Wallet.WalletDeduction
{
    public class CreateWalletDeductionRequestValidator : AbstractValidator<CreateWalletDeductionRequest>
    {
        public CreateWalletDeductionRequestValidator()
        {
            RuleFor(x => x.LeadId).NotEmpty();
            RuleFor(x => x.LeadIdNumber).NotEmpty();
            RuleFor(x => x.VendorId).NotEmpty();
            RuleFor(x => x.WalletStatus).NotEmpty();
            RuleFor(x => x.DeductedAmount).NotEmpty();
            RuleFor(x => x.DeductedDate).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
