using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.Repository;
using Happy.Weddings.Identity.Service.Queries.v1.Profile;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Identity.Service.Handlers.v1.Profile
{
    public class GetUserIdHandler : IRequestHandler<GetUserIdQuery, APIResponse>
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
        /// Initializes a new instance of the <see cref="GetUserIdHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetUserIdHandler(
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
        public async Task<APIResponse> Handle(GetUserIdQuery getQuery, CancellationToken cancellationToken)
        {
            try
            {
                var id = await repository.ProfileRepository.GetLastInsertedId();
                id++;
                string userId = getQuery.Parameters.IsUser ? string.Concat("HW_USER", id.ToString()):string.Concat("HW_VENDOR", id.ToString());
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
