#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  24-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | Handler class for create lead follow ups.
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
using System.Collections.Generic;
using Happy.Weddings.LeadManagement.Service.Commands.v1.Lead;
using Happy.Weddings.LeadManagement.Core.Repository;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using Happy.Weddings.LeadManagement.Core.Entity;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

#endregion

namespace Happy.Weddings.LeadManagement.Service.Handlers.v1.Lead
{
    /// <summary>
    /// Handler for creating follow lead.
    /// </summary>
    public class CreateLeadValidationHandler : IRequestHandler<CreateLeadValidationCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="CreateLeadValidationHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CreateLeadValidationHandler(
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
        public async Task<APIResponse> Handle(CreateLeadValidationCommand createCommand, CancellationToken cancellationToken)
        {
            try
            {
                var leadData = await repository.LeadRepository.GetLeadById(createCommand.LeadId);

                if (leadData == null) return new APIResponse(HttpStatusCode.NotFound);

                var leadFollowRequest = createCommand.Request;

                var leadFollow = new Leadvalidation()
                {
                    LeadId = leadData.Id,
                    CalledBy = leadFollowRequest.CalledBy,
                    CalledOn = leadFollowRequest.CalledOn,
                    Status = leadFollowRequest.Status,
                    Remark = leadFollowRequest.Remark,
                    FollowUpDate = leadFollowRequest.FollowUpDate,
                    CallRecordings = leadFollowRequest.CallRecordings,
                    CreatedAt = leadFollowRequest.CreatedAt,
                    CreatedBy = leadFollowRequest.CreatedBy,
                };

                leadData.Leadvalidation.Add(leadFollow);
                
                leadData.UpdatedAt = DateTime.UtcNow;
                leadData.UpdatedBy = leadFollowRequest.CreatedBy;

                repository.LeadRepository.UpdateLead(leadData);

                await repository.SaveAsync();

                return new APIResponse(createCommand.Request, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateFollowLeadHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
