#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | UpdateMultiCodeCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.LeadManagement.Core.DTO.Requests.MultiCode;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.LeadManagement.Service.Commands.v1.MultiCode
{
    /// <summary>
    /// Command for updating a MultiCode
    /// </summary>
    public class UpdateMultiCodeCommand   : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the multicode identifier.
        /// </summary>
        /// <value>
        /// The multicode identifier.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the reuqest.
        /// </summary>
        public UpdateMultiCodeRequest Request { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMultiCodeCommand" /> class.
        /// </summary>
        /// <param name="multicodeId">The multicode identifier.</param>
        /// <param name="Request">The request.</param>
        public UpdateMultiCodeCommand(string code, UpdateMultiCodeRequest request)
        {
            Code = code;
            Request = request;
        }
    }
}
