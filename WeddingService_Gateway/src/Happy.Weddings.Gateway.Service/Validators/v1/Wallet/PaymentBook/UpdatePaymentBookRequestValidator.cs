using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Happy.Weddings.Gateway.Core.DTO.Wallet.PaymentBook;

namespace Happy.Weddings.Gateway.Service.Validators.v1.Wallet.PaymentBook
{
    public class UpdatePaymentBookRequestValidator : AbstractValidator<UpdatePaymentBookRequest>
    {
        public UpdatePaymentBookRequestValidator()
        {
            RuleFor(x => x.EntryDate).NotEmpty();
            RuleFor(x => x.VendorId).NotEmpty();
            RuleFor(x => x.PaymentType).NotEmpty();
            RuleFor(x => x.PaymentAmount).NotEmpty();
            RuleFor(x => x.PaymentStatus).NotEmpty();
            RuleFor(x => x.WalletBalance).NotEmpty();
            RuleFor(x => x.PaymentMode).NotEmpty();
            RuleFor(x => x.UpdatedBy).NotEmpty();
        }
    }
}
