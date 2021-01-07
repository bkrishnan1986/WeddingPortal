using System;
using System.Collections.Generic;
using System.Text;

namespace Happy.Weddings.Gateway.Core.DTO.EventAssistant.MultiCode
{
    /// <summary>
    ///  This class is used to map Update MultiCode Request
    /// </summary>
    public class UpdateMultiCodeRequsts
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
        /// Gets or sets the status.
        /// </summary>
        public short Active { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        public int UpdatedBy { get; set; }
    }
}
