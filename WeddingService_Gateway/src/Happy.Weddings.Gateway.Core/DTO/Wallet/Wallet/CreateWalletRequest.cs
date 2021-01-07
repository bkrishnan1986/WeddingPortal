using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.Wallet
{
    public class CreateWalletRequest
    {
        /// <summary>
        /// Gets or sets the VendorId.
        /// </summary>
        public int VendorId { get; set; }

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the Balance.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy.
        /// </summary>
        public int CreatedBy { get; set; }
    }
}
