#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  09-Sep-2020 |    Sumith C       | Created and implemented. 
//              |                   | Handler class for getting lead Assig.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Serilog;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Happy.Weddings.LeadManagement.Core.Repository;
using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using Happy.Weddings.LeadManagement.Service.Queries.v1.Lead;

#endregion

namespace Happy.Weddings.LeadManagement.Service.Handlers.v1.Lead
{
    /// <summary>
    /// Handler for getting a lead Assign.
    /// </summary>
    public class GetAllLeadAssignHandler : IRequestHandler<GetAllLeadAssignQuery, APIResponse>
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
        /// Initializes a new instance of the <see cref="GetAllLeadAssignHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetAllLeadAssignHandler(
            IRepositoryWrapper repository,
            ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        /// <summary>
        /// Handles the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<APIResponse> Handle(GetAllLeadAssignQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var leadAssign = await repository.LeadAssignRepository.GetAllLeadAssign(query.LeadAssignParameter);

                if (null == leadAssign) return new APIResponse(HttpStatusCode.NotFound);

                return new APIResponse(leadAssign, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllLeadAssignHandler");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
