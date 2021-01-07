using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Wallet.Transactions;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Wallet.Transactions
{
    public class TransactionsIdDetailsValidator : AbstractValidator<TransactionsIdDetails>
    {
        public TransactionsIdDetailsValidator()
        {
            RuleFor(x => x.TransactionsId).NotEmpty();
        }
    }
}
