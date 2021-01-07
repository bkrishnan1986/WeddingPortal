#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  18-SEP-2020 |    NIKHIL K DAS  | Created and implemented. 
//              |                      | UpdateWalletCommand --class
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Wallet.Core.DTO.Requests.Wallet;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Wallet.Service.Commands.v1.Wallet
{
    /// <summary>
    /// Command for updating a Wallet
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class UpdateWalletCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the Wallet identifier.
        /// </summary>
        /// <value>
        /// The Wallet identifier.
        /// </value>
        public int WalletId { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateWalletRequest Request { get; set; }

        public bool IsPaused { get; set; }
        public bool IsReleased { get; set; }
        public bool IsChurned { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateWalletCommand" /> class.
        /// </summary>
        /// <param name="walletId">The Wallet identifier.</param>
        /// <param name="request">The request.</param>
        /// <param name="isPaused">IsPaused Status.</param>
        /// <param name="isReleased">IsReleased Status.</param>
        /// <param name="isChurned">IsChurned Status.</param>
        public UpdateWalletCommand(int walletId, UpdateWalletRequest request, bool isPaused = false, bool isReleased = false, bool isChurned = false)
        {
            WalletId = walletId;
            Request = request;
            IsPaused = isPaused;
            IsReleased = isReleased;
            IsChurned = isChurned;
        }
    }
}
