using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletAdjustment;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Wallet.WalletAdjustment
{
    public class CreateWalletAdjustmentRequestValidator : AbstractValidator<CreateWalletAdjustmentRequest>
    {
        public CreateWalletAdjustmentRequestValidator()
        {
            RuleFor(x => x.VendorId).NotEmpty();
            RuleFor(x => x.AdjustmentType).NotEmpty();
            RuleFor(x => x.AdjustmentAmount).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
