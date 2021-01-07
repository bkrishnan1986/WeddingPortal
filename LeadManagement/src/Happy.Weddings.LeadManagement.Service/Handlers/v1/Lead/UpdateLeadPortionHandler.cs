#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | Handler class for update lead portion.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using AutoMapper;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using Happy.Weddings.LeadManagement.Core.Entity;
using Happy.Weddings.LeadManagement.Core.Repository;
using Happy.Weddings.LeadManagement.Service.Commands.v1.Lead;
using MediatR;
using Serilog;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace Happy.Weddings.LeadManagement.Service.Handlers.v1.Lead
{
    /// <summary>
    /// Handler for updating user profile portion.
    /// </summary>
    public class UpdateLeadPortionHandler : IRequestHandler<UpdateLeadPortionCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="UpdateLeadPortionHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UpdateLeadPortionHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<APIResponse> Handle(UpdateLeadPortionCommand updateCommand, CancellationToken cancellationToken)
        {
            try
            {
                var leadData = await repository.LeadRepository.GetLeadById(updateCommand.Id);

                if (leadData == null) return new APIResponse(HttpStatusCode.NotFound);

                leadData.LeadQuality = updateCommand.Request.LeadQuality ;
                leadData.LeadStatusId = updateCommand.Request.LeadStatus;
                leadData.UpdatedAt = DateTime.UtcNow;
                leadData.UpdatedBy = updateCommand.Request.UpdatedBy;

                var leadStatus = new Leadstatus
                {
                    LeadId = leadData.Id,
                    LeadStatusId = updateCommand.Request.LeadStatus,
                    Date = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    CreatedBy = updateCommand.Request.UpdatedBy,
                };

                leadData.Leadstatus.Add(leadStatus);

                repository.LeadRepository.UpdateLead(leadData);

                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateLeadPortionHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
