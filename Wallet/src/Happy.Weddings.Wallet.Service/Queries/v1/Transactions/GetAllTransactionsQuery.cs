using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.Transactions;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Queries.v1.Transactions
{
    /// <summary>
    /// Query for getting Transactions
    /// </summary>
    /// <seealso cref="MediatR.IRequest{System.Collections.Generic.List{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}}" />
    public class GetAllTransactionsQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Transactions parameters.
        /// </summary>
        public TransactionsParameter TransactionsParameter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllPaymentBookQuery"/> class.
        /// </summary>
        /// <param name="transactionsParameter">The Transactions parameters.</param>
        public GetAllTransactionsQuery(TransactionsParameter transactionsParameter)
        {
            TransactionsParameter = transactionsParameter;
        }
    }
}
