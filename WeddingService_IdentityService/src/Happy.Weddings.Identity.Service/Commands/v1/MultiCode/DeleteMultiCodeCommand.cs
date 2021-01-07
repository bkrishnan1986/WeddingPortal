﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | DeleteMultiCodeCommand --class
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Identity.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Identity.Service.Commands.v1.MultiCode
{
    /// <summary>
    /// Command for deleting a multicode
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Happy.Weddings.Identity.Core.DTO.Responses.APIResponse}" />
    public class DeleteMultiCodeCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the multicode identifier.
        /// </summary>
        /// <value>
        /// The multicode identifier.
        /// </value>
        public string Code { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMultiCodeCommand"/> class.
        /// </summary>
        /// <param name="multicodeId">The multicode identifier.</param>
        public DeleteMultiCodeCommand(string code)
        {
            Code = code;
        }
    }
}
