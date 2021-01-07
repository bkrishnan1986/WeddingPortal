using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Wallet.Multicode;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Wallet.Multicode
{
    public class UpdateMulticodeRequestValidator : AbstractValidator<UpdateMulticodeWalletRequest>
    {
        public UpdateMulticodeRequestValidator()
        {
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
