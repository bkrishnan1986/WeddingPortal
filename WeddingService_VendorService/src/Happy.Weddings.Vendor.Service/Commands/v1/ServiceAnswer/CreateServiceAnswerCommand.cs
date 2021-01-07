#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  03-Sep-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | CreateServiceAnswerCommand --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Requests.ServiceAnswer;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using MediatR;

namespace Happy.Weddings.Vendor.Service.Commands.v1.ServiceAnswer
{
    public class CreateServiceAnswerCommand : IRequest<APIResponse>
    {
        /// <summary>
        /// Gets or sets the service answer request.
        /// </summary>
        /// <value>
        /// The service answer request.
        /// </value>
        public ServiceAnswerRequest ServiceAnswerRequest { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateServiceAnswerCommand"/> class.
        /// </summary>
        /// <param name="serviceanswerrequest">The serviceanswerrequest.</param>
        public CreateServiceAnswerCommand(ServiceAnswerRequest serviceanswerrequest)
        {
            ServiceAnswerRequest = serviceanswerrequest;
        }
    }
}
