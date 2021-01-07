#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  03-Aug-2020 |    Reji Salooja B S    | Created and implemented. 
//              |                         | UpdateMultiCodeRequest
//----------------------------------------------------------------------------------------------

#endregion

namespace Happy.Weddings.Wallet.Core.DTO.Requests.MultiCode
{
    /// <summary>
    ///  This class is used to map Update MultiCode Request
    /// </summary>
    public class UpdateMultiCodeRequest
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
