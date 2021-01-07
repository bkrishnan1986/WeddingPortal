#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | Handler class for lead assign.
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
    /// Handler for creating assign lead.
    /// </summary>
    public class CreateLeadAssignHandler : IRequestHandler<CreateLeadAssignCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="CreateLeadAssignHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CreateLeadAssignHandler(
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
        public async Task<APIResponse> Handle(CreateLeadAssignCommand createCommand, CancellationToken cancellationToken)
        {
            try
            {
                var leadData = await repository.LeadRepository.GetLeadById(createCommand.LeadId);

                if (leadData == null) return new APIResponse(HttpStatusCode.NotFound);

                var leadAssignRequest = createCommand.Request;
                var leadStatusRequest = leadAssignRequest.LeadStatusRequest.First();

                var leadAssign = new Leadassign()
                {
                    LeadId = leadData.Id,
                    LeadSentDate = leadAssignRequest.LeadSentDate,
                    VendorId = leadAssignRequest.VendorId,
                    VendorName = leadAssignRequest.VendorName,
                    Category = leadAssignRequest.Category,
                    ProposedBudget = leadAssignRequest.ProposedBudget,
                    Packs = leadAssignRequest.Packs,
                    Remarks = leadAssignRequest.Remarks,
                    CreatedAt = leadAssignRequest.CreatedAt,
                    CreatedBy = leadAssignRequest.CreatedBy,
                };

                var leadStatus = new Leadstatus
                {
                    LeadId = leadData.Id,
                    LeadStatusId = leadStatusRequest.LeadStatusId,
                    Date = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    CreatedBy = leadAssignRequest.CreatedBy
                };

                leadData.Leadassign.Add(leadAssign);
                leadData.Leadstatus.Add(leadStatus);

                leadData.LeadStatusId = leadStatusRequest.LeadStatusId;
                leadData.UpdatedAt = DateTime.UtcNow;
                leadData.UpdatedBy = leadAssignRequest.CreatedBy;

                if (leadData.Leadassign != null && leadData.Leadassign.Count > 0)
                {
                    foreach (var item in leadData.Leadassign)
                    {
                        repository.LeadAssignRepository.CreateLeadAssign(item);
                    }
                }

                await repository.SaveAsync();

                return new APIResponse(createCommand.Request, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateAssignLeadHandler'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
