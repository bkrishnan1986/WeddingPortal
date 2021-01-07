﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | DeleteMultiCodeHandler --class
//----------------------------------------------------------------------------------------------

#endregion

using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using Happy.Weddings.Wallet.Service.Commands.v1.MultiCode;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.Service.Handlers.v1.MultiCode
{
    /// <summary>
    /// Handler for Deleting a multicode
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Wallet.Service.Commands.v1.MultiCode.DeleteMultiCodeCommand, Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class DeleteMultiCodeHandler : IRequestHandler<DeleteMultiCodeCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="DeleteMultiCodeHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public DeleteMultiCodeHandler(
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
        public async Task<APIResponse> Handle(DeleteMultiCodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var multicode = await repository.MultiCodes.GetMultiCode(request.Code);

                if (multicode == null) return new APIResponse(HttpStatusCode.NotFound);

                var multidetail = await repository.MultiDetails.GetMultiDetailsByCode(request.Code);

                if (multidetail == null || multidetail.Count == 0)
                {
                    multicode.Active = 0;

                    repository.MultiCodes.UpdateMultiCode(multicode);
                    await repository.SaveAsync();
                }

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteMultiCodeHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
