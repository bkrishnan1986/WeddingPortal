﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | GetEventHandler --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Queries.v1.Event;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.Event
{
    /// <summary>
    /// Handler for getting a event
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Vendor.Service.v1.Queries.GetEventQuery, Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    /// 
    public class GetEventHandler : IRequestHandler<GetEventQuery, APIResponse>
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
        /// Initializes a new instance of the <see cref="GetEventHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>

        public GetEventHandler(
            IRepositoryWrapper repository,
            ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<APIResponse> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var events = await repository.Events.GetEventById(request.Id);
                if (events == null)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }

                return new APIResponse(events, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetEventHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
