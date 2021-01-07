#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | Handler class for deactivate lead.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using Happy.Weddings.LeadManagement.Core.Repository;
using Happy.Weddings.LeadManagement.Service.Commands.v1.Lead;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace Happy.Weddings.LeadManagement.Service.Handlers.v1.Story
{
    /// <summary>
    /// Handler for deleting a story
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.LeadManagement.Service.v1.Commands.DeleteStoryCommand, Happy.Weddings.LeadManagement.Core.DTO.Responses.APIResponse}" />
    public class DeleteLeadHandler : IRequestHandler<DeleteLeadCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="DeleteLeadHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public DeleteLeadHandler(
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
        public async Task<APIResponse> Handle(DeleteLeadCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var leadData = await repository.LeadRepository.GetLeadById(request.LeadId);
                if (leadData == null)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }

                leadData.Active  = 0;

                repository.LeadRepository.UpdateLead(leadData);

                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteLeadHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
