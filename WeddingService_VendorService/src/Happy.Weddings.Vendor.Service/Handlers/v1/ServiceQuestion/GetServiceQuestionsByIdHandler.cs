using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Queries.v1.ServiceQuestion;
using MediatR;
using Serilog;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.ServiceQuestion
{
    public class GetServiceQuestionsByIdHandler : IRequestHandler<GetServiceQuestionsByIdQuery, APIResponse>
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
        /// Initializes a new instance of the <see cref="GetServiceQuestionsByIdHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetServiceQuestionsByIdHandler(
           IRepositoryWrapper repository,
           ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<APIResponse> Handle(GetServiceQuestionsByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var servicequestions = await repository.ServiceQuestion.GetServiceQuestionsById(request.serviceQuestionServiceTypeParameters);
                return new APIResponse(servicequestions, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetServiceQuestionsByIdHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
