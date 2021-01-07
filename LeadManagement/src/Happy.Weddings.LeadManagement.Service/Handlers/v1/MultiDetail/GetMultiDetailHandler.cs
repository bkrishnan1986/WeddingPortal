﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | GetMultiDetailHandler --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using Happy.Weddings.LeadManagement.Core.Repository;
using Happy.Weddings.LeadManagement.Service.Queries.v1.MultiDetail;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.LeadManagement.Service.Handlers.v1.MultiDetail
{
    /// <summary>
    /// Handler for getting  multidetail
    /// </summary>
    public class GetMultiDetailHandler : IRequestHandler<GetMultiDetailsByIdQuery, APIResponse>
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
        /// Initializes a new instance of the <see cref="GetMultiDetailHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetMultiDetailHandler(
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
        public async Task<APIResponse> Handle(GetMultiDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var multidetail = await repository.MultiDetails.GetMultiDetailsByCode(request.Code);

                if (multidetail == null) return new APIResponse(HttpStatusCode.NotFound);

                return new APIResponse(multidetail, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetMultiDetailHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
