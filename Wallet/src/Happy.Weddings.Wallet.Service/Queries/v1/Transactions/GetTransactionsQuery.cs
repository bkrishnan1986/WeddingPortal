using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Queries.v1.Transactions
{
    /// <summary>
    /// Query for getting a Transactions
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}}" />
    public class GetTransactionsQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Transactions identifier.
        /// </summary>
        public int TransactionId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTransactionsQuery"/> class.
        /// </summary>
        /// <param name="transactionId">The Transactions identifier.</param>
        public GetTransactionsQuery(int transactionId)
        {
            TransactionId = transactionId;
        }
    }
}
