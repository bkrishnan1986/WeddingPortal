#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    Reji Salooja B  S  | Created and implemented. 
//              |                       | CreateServiceQuestionRequest class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System.Collections.Generic;

namespace Happy.Weddings.Gateway.Core.DTO.Vendor.ServiceQuestion
{
    public class CreateServiceQuestionRequest
    {
        /// <summary>
        /// Gets or sets the question.
        /// </summary>
        /// <value>
        /// The question.
        /// </value>
        public string Question { get; set; }
        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        /// <value>
        /// The type of the service.
        /// </value>
        public int ServiceType { get; set; }
        /// <summary>
        /// Gets or sets the IsVendorFor
        /// </summary>
        public short IsForVendor { get; set; }
        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        /// <value>
        /// The active.
        /// </value>
        public short Active { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        public int CreatedBy { get; set; }
    }
    public class CreateVendorQuestionAnswerRequest
    {
        public IEnumerable<CreateServiceQuestionRequest> VendorQuestionAnswers { get; set; }
    }
}
