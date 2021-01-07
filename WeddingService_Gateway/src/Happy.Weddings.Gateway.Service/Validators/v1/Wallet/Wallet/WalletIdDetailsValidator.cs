﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Wallet.Wallet;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Wallet.Wallet
{
    public class WalletIdDetailsValidator : AbstractValidator<WalletIdDetails>
    {
        public WalletIdDetailsValidator()
        {
            RuleFor(x => x.WalletId).NotEmpty();
        }
    }
}
