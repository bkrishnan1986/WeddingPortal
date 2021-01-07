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
    public class GetAllLeadTotalAmtHandler : IRequestHandler<GetAllLeadTotalAmountQuery, APIResponse>
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
        /// Initializes a new instance of the <see cref="GetAllLeadQuoteHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetAllLeadTotalAmtHandler(
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
        public async Task<APIResponse> Handle(GetAllLeadTotalAmountQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var leadTotAmt = await repository.LeadTotalAmtRepository.GetLeadTotalAmount(query.LeadCountTotAmt, query.VendorId);

                if (null == leadTotAmt) return new APIResponse(HttpStatusCode.NotFound);
                decimal LeadTotalAmt = 0;
                
                foreach (var tot in leadTotAmt)
                {
                    LeadTotalAmt += tot.Lead.Revenue??0;
                }
                return new APIResponse(new LeadTotalAmtResponse { TotalAmt = LeadTotalAmt }, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllLeadStatusHandler");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
