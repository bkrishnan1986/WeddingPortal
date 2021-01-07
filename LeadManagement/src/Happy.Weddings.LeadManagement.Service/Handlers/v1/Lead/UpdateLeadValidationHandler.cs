#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Oct-2020 |    Sumith C       | Created and implemented. 
//              |                   | Handler class for update lead Validation.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using Happy.Weddings.LeadManagement.Core.Entity;
using Happy.Weddings.LeadManagement.Core.Repository;
using Happy.Weddings.LeadManagement.Service.Commands.v1.Lead;
using MediatR;
using Serilog;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace Happy.Weddings.LeadManagement.Service.Handlers.v1.Lead
{
    /// <summary>
    /// Handler for updating lead Validation
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.LeadManagement.Service.Commands.v1.Lead.UpdateLeadValidationCommand, Happy.Weddings.LeadManagement.Core.DTO.Responses.APIResponse}" />
    public class UpdateLeadValidationHandler : IRequestHandler<UpdateLeadValidationCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="UpdateLeadValidationHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UpdateLeadValidationHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        /// <summary>
        /// Handles the specified update command.
        /// </summary>
        /// <param name="updateCommand">The update command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<APIResponse> Handle(UpdateLeadValidationCommand updateCommand, CancellationToken cancellationToken)
        {
            try
            {
                var leadValidation = await repository.LeadValidationRepository.GetLeadValidation(updateCommand.Id);

                if (leadValidation == null) return new APIResponse(HttpStatusCode.NotFound);

                var validation = mapper.Map(updateCommand.Request, leadValidation);

                repository.LeadValidationRepository.UpdateLeadValidation(validation);

                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateLeadvalidationHandler");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
