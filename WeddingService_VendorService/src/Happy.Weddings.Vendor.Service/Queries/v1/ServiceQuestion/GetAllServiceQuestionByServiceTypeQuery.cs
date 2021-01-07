#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 02-Sep-2020 | Reji Salooja B S  | Created and implemented.
//                                 |  GetAllServiceQuestionByServiceTypeQuery class.
//----------------------------------------------------------------------------------------------

#endregion File Header    

using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceQuestion;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Queries.v1.ServiceQuestion
{
   public class GetAllServiceQuestionByServiceTypeQuery : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the service type identifier.
        /// </summary>
        /// <value>
        /// The service type identifier.
        /// </value>
        public ServiceQuestionParameters serviceQuestionParameters { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllServiceQuestionByServiceTypeQuery"/> class.
        /// </summary>
        /// <param name="serviceTypeId">The service type identifier.</param>
        public GetAllServiceQuestionByServiceTypeQuery(ServiceQuestionParameters serviceQuestionParameters)
        {
            this.serviceQuestionParameters = serviceQuestionParameters;
        }
    }
}
