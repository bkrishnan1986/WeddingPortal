using System;
using System.Collections.Generic;
using System.Text;
using Happy.Weddings.Wallet.Core.DTO.Requests.Transactions;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Commands.v1.Transactions
{
    /// <summary>
    /// Command for creating a Transaction
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class CreateTransactionsCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public CreateTransactionsRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTransactionsCommand"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateTransactionsCommand(CreateTransactionsRequest request)
        {
            Request = request;
        }
    }
}
