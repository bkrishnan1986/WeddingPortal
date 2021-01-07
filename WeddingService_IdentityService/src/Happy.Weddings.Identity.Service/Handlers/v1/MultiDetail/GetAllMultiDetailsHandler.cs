#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | GetAllMultiDetailsHandler --class
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.Repository;
using Happy.Weddings.Identity.Service.Queries.v1.MultiDetail;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Identity.Service.Handlers.v1.MultiDetail
{
    /// <summary>
    /// Handler for getting all multidetails
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Identity.Service.Queries.v1.MultiDetail.GetAllMultiDetailsQuery, Happy.Weddings.Identity.Core.DTO.Responses.APIResponse}" />
    public class GetAllMultiDetailsHandler : IRequestHandler<GetAllMultiDetailsQuery, APIResponse>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IRepositoryWrapper repository;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllMultiDetailsHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetAllMultiDetailsHandler(
            IRepositoryWrapper repository,
            ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<APIResponse> Handle(GetAllMultiDetailsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var multidetails = await repository.MultiDetails.GetMultiDetails(request.MultiDetailParameters);
                return new APIResponse(multidetails, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllMultiDetailsHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
