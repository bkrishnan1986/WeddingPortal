#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  03-Aug-2020 |    Reji Salooja B  S    | Created and implemented. 
//              |                        | CreateMultiCodeRequest
//----------------------------------------------------------------------------------------------

#endregion File Header

namespace Happy.Weddings.LeadManagement.Core.DTO.Requests.MultiCode
{
    /// <summary>
    ///  This class is used to map Create MultiCode Request
    /// </summary>
    public class CreateMultiCodeRequest
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets IsRequired.
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        public int CreatedBy { get; set; }
    }
}
