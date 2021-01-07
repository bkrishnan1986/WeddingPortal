#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Oct-2020 |    Sumith C       | Created and implemented. 
//              |                   | Handler class for deactivate lead quote.
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
    /// Handler for deactivate lead quote.
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.LeadManagement.Service.Commands.v1.Lead.DeleteLeadQuoteCommand, Happy.Weddings.LeadManagement.Core.DTO.Responses.APIResponse}" />
    public class DeleteLeadQuoteHandler : IRequestHandler<DeleteLeadQuoteCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="DeleteLeadQuoteHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public DeleteLeadQuoteHandler(
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
        public async Task<APIResponse> Handle(DeleteLeadQuoteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var leadQuote = await repository.LeadQuoteRepository.GetLeadQuoteById(request.QuoteId);

                if (leadQuote == null) return new APIResponse(HttpStatusCode.NotFound);

                leadQuote.Active = 0;
                repository.LeadQuoteRepository.UpdateLeadQuote(leadQuote);

                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'DeleteLeadQuoteHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
