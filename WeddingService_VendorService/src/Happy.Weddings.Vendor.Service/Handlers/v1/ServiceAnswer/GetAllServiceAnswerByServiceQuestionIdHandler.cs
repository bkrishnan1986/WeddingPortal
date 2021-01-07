using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Queries.v1.ServiceAnswer;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.ServiceAnswer
{
    public class GetAllServiceAnswerByServiceQuestionIdHandler : IRequestHandler<GetAllServiceAnswerByServiceQuestionQuery, APIResponse>
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
        /// Initializes a new instance of the <see cref="GetAllServiceQuestionsByServiceTypeHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetAllServiceAnswerByServiceQuestionIdHandler(
           IRepositoryWrapper repository,
           ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<APIResponse> Handle(GetAllServiceAnswerByServiceQuestionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var serviceanswers = await repository.ServiceAnswer.GetServiceAnswerByQuestionId(request.QuestionId);
                return new APIResponse(serviceanswers, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllServiceAnswerByServiceQuestionIdHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
