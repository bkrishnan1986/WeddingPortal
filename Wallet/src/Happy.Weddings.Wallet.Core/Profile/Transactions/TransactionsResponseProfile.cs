using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Responses.Transactions;

namespace Happy.Weddings.Wallet.Core.Profile.Transactions
{
    public class TransactionsResponseProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionsResponseProfile"/> class.
        /// </summary>
        public TransactionsResponseProfile()
        {
            CreateMap<Entity.Transactions, TransactionsResponse>()
                .ForMember(x => x.TransactionTypeName, opt => opt.MapFrom(o => o.TransactionTypeNavigation != null ? o.TransactionTypeNavigation.Value : ""));
        }
    }
}
