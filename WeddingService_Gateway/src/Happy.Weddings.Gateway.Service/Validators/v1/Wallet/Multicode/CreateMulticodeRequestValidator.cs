using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Wallet.Multicode;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Wallet.Multicode
{
    public class CreateMulticodeRequestValidator : AbstractValidator<CreateMulticodeWalletRequest>
    {
        public CreateMulticodeRequestValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.CreatedBy).NotEmpty();
        }
    }
}
