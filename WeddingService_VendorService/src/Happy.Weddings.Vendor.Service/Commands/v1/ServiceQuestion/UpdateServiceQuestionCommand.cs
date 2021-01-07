#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
// 03-Sep-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                     | UpdateServiceQuestionCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceQuestion;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.ServiceQuestion
{
   public class UpdateServiceQuestionCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the service question request.
        /// </summary>
        /// <value>
        /// The service question request.
        /// </value>
        public UpdateServiceQuestionRequest ServiceQuestionRequest { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateServiceQuestionCommand"/> class.
        /// </summary>
        /// <param name="servicequestionrequest">The servicequestionrequest.</param>
        public UpdateServiceQuestionCommand(int questionId, UpdateServiceQuestionRequest servicequestionrequest)
        {
            Id = questionId;
            ServiceQuestionRequest = servicequestionrequest;
        }
    }
}
