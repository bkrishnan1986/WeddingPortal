using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Queries.v1.ServicesOffered;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.ServicesOffered
{
    public class GetServicesOfferedByServiceIdHandler : IRequestHandler<GetServicesOfferedByServiceIdQuery, APIResponse>
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
        /// Initializes a new instance of the <see cref="GetServicesOfferedByServiceIdHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetServicesOfferedByServiceIdHandler(
          IRepositoryWrapper repository,
          ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }
        public async Task<APIResponse> Handle(GetServicesOfferedByServiceIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var services = await repository.ServiceOffer.GetServicesOfferedByServiceId(request.ServiceId);
                return new APIResponse(services, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetServicesOfferedByServiceIdHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
