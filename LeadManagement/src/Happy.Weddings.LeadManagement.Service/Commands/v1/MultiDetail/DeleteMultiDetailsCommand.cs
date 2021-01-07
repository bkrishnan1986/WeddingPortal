#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | DeleteMultiDetailsCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.LeadManagement.Service.Commands.v1.MultiDetail
{
    /// <summary>
    /// Command for deleting a multidetail
    /// </summary>
    public class DeleteMultiDetailsCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the multidetail identifier.
        /// </summary>
        /// <value>
        /// The multidetail identifier.
        /// </value>
        public int MultiDetailId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMultiDetailsCommand"/> class.
        /// </summary>
        /// <param name="multidetailId">The multidetail identifier.</param>
        public DeleteMultiDetailsCommand(int multidetailId)
        {
            MultiDetailId = multidetailId;
        }
    }
}
