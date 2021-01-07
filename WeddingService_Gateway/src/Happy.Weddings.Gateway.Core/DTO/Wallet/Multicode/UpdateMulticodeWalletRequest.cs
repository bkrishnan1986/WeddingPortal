using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.Wallet.Multicode
{
    public class UpdateMulticodeWalletRequest
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        public int UpdatedBy { get; set; }
    }
}
