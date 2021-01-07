using Happy.Weddings.LeadManagement.Core.DTO.Responses;
using Happy.Weddings.LeadManagement.Core.Repository;
using Happy.Weddings.LeadManagement.Service.Queries.v1.Lead;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.LeadManagement.Service.Handlers.v1.Lead
{
    public class GetLeadIdHandler : IRequestHandler<GetLeadIdQuery, APIResponse>
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
        /// Initializes a new instance of the <see cref="GetLeadIdHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetLeadIdHandler(
            IRepositoryWrapper repository,
            ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        /// <summary>
        /// Handles the specified get query.
        /// </summary>
        /// <param name="getQuery">The get query.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<APIResponse> Handle(GetLeadIdQuery getQuery, CancellationToken cancellationToken)
        {
            try
            {
                var id = await repository.LeadRepository.GetLastInsertedId();
                id++;
                string userId = string.Concat("HW_LEAD", id.ToString());
                return new APIResponse(userId, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetUserIdHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}