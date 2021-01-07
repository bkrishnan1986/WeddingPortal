#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 02-Sep-2020 | Reji Salooja B S  | Created and implemented.
//                                 |  GetAllServiceAnswerByServiceQuestionQuery class.
//----------------------------------------------------------------------------------------------

#endregion File Header    

using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.ServiceAnswer
{
    public class GetAllServiceAnswerByServiceQuestionQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the question identifier.
        /// </summary>
        /// <value>
        /// The question identifier.
        /// </value>
        public int QuestionId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllServiceAnswerByServiceQuestionQuery"/> class.
        /// </summary>
        /// <param name="questionId">The question identifier.</param>
        public GetAllServiceAnswerByServiceQuestionQuery(int questionId)
        {
            QuestionId = questionId;
        }
    }
}
