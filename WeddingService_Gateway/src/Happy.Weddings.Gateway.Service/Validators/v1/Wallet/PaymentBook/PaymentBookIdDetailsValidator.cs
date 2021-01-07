using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Wallet.PaymentBook;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Wallet.PaymentBook
{
    public class PaymentBookIdDetailsValidator : AbstractValidator<PaymentBookIdDetails>
    {
        public PaymentBookIdDetailsValidator()
        {
            RuleFor(x => x.PaymentBookId).NotEmpty();
        }
    }
}
