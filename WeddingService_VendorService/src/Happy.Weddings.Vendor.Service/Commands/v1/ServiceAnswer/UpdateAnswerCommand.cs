#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  03-Sep-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | UpdateAnswerCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceAnswer;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.ServiceAnswer
{
    public class UpdateAnswerCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the question identifier.
        /// </summary>
        /// <value>
        /// The question identifier.
        /// </value>
        public int QuestionId { get; set; }
        /// <summary>
        /// Gets or sets the service answer details.
        /// </summary>
        /// <value>
        /// The service answer details.
        /// </value>
        public ServiceAnswerDetails ServiceAnswerDetails{ get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateAnswerCommand"/> class.
        /// </summary>
        /// <param name="serviceAnswerDetails">The service answer details.</param>
        public UpdateAnswerCommand(int questionId, ServiceAnswerDetails serviceAnswerDetails)
        {
            QuestionId = questionId;
            ServiceAnswerDetails = serviceAnswerDetails;
        }
    }
}
