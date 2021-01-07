#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  08-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | Handler class for create lead.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using AutoMapper;
using Happy.Weddings.LeadManagement.Core.DTO.Requests.Lead;
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
    /// Handler for lead creation
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.LeadManagement.Service.Commands.v1.Lead.CreateLeadCommand, Happy.Weddings.LeadManagement.Core.DTO.Responses.APIResponse}" />
    public class CreateLeadHandler : IRequestHandler<CreateLeadCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="CreateLeadHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CreateLeadHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
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
        public async Task<APIResponse> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var apiStatus = HttpStatusCode.Created;

                var leadCollectionData = await repository.LeadDataRepository.GetLeadWithDetails(request.Request.CustomerPhone1);

                if (leadCollectionData == null)
                {
                    leadCollectionData = mapper.Map<Leaddatacollection>(request.Request);
                    repository.LeadDataRepository.CreateLead(leadCollectionData);
                }
                else
                {
                    var leadRequest = request.Request.Leads.First();
                    var leadStatusRequest = leadRequest.LeadStatus.First();
                    var isLeadExist = leadCollectionData.Leads.Any(x => x.EventType == leadRequest.EventType && 
                        x.Category == leadRequest.Category);
                    if (!isLeadExist)
                    {
                        var leadData = new Leads
                        {
                            DataCollectionId = leadCollectionData.Id,
                            Budget = leadRequest.Budget,
                            Description = leadRequest.Description,
                            EventDate = leadRequest.EventDate,
                            EventLocation = leadRequest.EventLocation,
                            LeadId = leadRequest.LeadId,
                            LeadMode = leadRequest.LeadMode,
                            LeadQuality = leadRequest.LeadQuality,
                            LeadType = leadRequest.LeadType,
                            Owner = leadRequest.Owner,
                            OwnerName=leadRequest.OwnerName,
                            Revenue = leadRequest.Revenue,
                            EventType = leadRequest.EventType,
                            Category = leadRequest.Category,
                            LeadStatusId = leadRequest.LeadStatusId,
                            Cplvalue = leadRequest.Cplvalue,
                            CommisionValue = leadRequest.CommisionValue,
                            WalletStatus = leadRequest.WalletStatus,
                            CreatedAt = DateTime.UtcNow,
                            CreatedBy = request.Request.CreatedBy
                        };

                        var leadStatus = new Leadstatus
                        {
                            LeadId = leadData.Id,
                            LeadStatusId = leadStatusRequest.LeadStatusId,
                            Date = DateTime.UtcNow,
                            CreatedAt = DateTime.UtcNow,
                            CreatedBy = request.Request.CreatedBy
                        };

                        leadData.Leadstatus.Add(leadStatus);
                        leadCollectionData.Leads.Add(leadData);
                        leadCollectionData.UpdatedAt = DateTime.UtcNow;
                        leadCollectionData.UpdatedBy = request.Request.CreatedBy;
                    }
                    else
                    {
                        apiStatus = HttpStatusCode.Ambiguous;
                    }

                    repository.LeadDataRepository.Update(leadCollectionData);
                }
                await repository.SaveAsync();
                var id = leadCollectionData.Leads.Last().Id;
                return new APIResponse(new LeadIdDetails { LeadId = id }, apiStatus);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateLeadHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
