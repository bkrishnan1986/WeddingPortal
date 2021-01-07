using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.Transactions;

namespace Happy.Weddings.Wallet.Core.Profile.Transactions
{
    public class CreateTransactionsProfile : AutoMapper.Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTransactionsProfile"/> class.
        /// </summary>
        public CreateTransactionsProfile()
        {
            CreateMap<CreateTransactionsRequest, Entity.Transactions>()
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(o => DateTime.UtcNow));
        }
    }
}
