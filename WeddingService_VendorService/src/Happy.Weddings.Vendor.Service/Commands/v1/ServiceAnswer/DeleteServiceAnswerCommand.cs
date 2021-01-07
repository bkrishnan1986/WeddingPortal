#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  03-Sep-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | DeleteServiceAnswerCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header  

using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceAnswer;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.ServiceAnswer
{
    public class DeleteServiceAnswerCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteServiceQuestionCommand"/> class.
        /// </summary>
        /// <param name="questionId">The question identifier.</param>
        public DeleteServiceAnswerCommand(int questionId)
        {
            Id = questionId; 
        }
    }
}
