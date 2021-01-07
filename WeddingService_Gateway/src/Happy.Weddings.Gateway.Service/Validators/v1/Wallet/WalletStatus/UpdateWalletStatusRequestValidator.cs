using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Wallet.WalletStatus;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Wallet.WalletStatus
{
    public class UpdateWalletStatusRequestValidator : AbstractValidator<UpdateWalletStatusRequest>
    {
        public UpdateWalletStatusRequestValidator()
        {           
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
