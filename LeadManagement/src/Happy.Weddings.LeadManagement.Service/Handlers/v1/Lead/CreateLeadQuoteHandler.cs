#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Oct-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateKYCDataHandler class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using Serilog;
using System;
using System.Net;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Happy.Weddings.LeadManagement.Core.Repository;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using Happy.Weddings.LeadManagement.Core.Entity;
using System.Collections.Generic;
using Happy.Weddings.LeadManagement.Service.Commands.v1.Lead;

#endregion

namespace Happy.Weddings.LeadManagement.Service.Handlers.v1.Lead
{
    /// <summary>
    /// Handler for creating lead quote.
    /// </summary>
    public class CreateLeadQuoteHandler : IRequestHandler<CreateLeadQuoteCommand, APIResponse>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IRepositoryWrapper repository;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLeadQuoteHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CreateLeadQuoteHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        /// <summary>
        /// Handles the specified create command.
        /// </summary>
        /// <param name="createCommand">The create command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<APIResponse> Handle(CreateLeadQuoteCommand createCommand, CancellationToken cancellationToken)
        {
            try
            {
                List<Leadquote> leadquotes = new List<Leadquote>();

                foreach (var item in createCommand.Request.LeadQuotes)
                {
                    var kycDataRequest = mapper.Map<Leadquote>(item);
                    kycDataRequest.LeadId = createCommand.LeadId;
                    leadquotes.Add(kycDataRequest);
                }

                repository.LeadQuoteRepository.CreateLeadQuote(leadquotes);

                await repository.SaveAsync();

                return new APIResponse(createCommand.Request, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateLeadQuoteDataHandler'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
