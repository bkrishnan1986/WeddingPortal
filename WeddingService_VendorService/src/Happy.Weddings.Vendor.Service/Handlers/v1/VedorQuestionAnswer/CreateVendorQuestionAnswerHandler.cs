using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Commands.v1.VendorQuestionAnswer;
using MediatR;
using Serilog;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.VedorQuestionAnswer
{
    public class CreateVendorQuestionAnswerHandler : IRequestHandler<CreateVendorQuestionAnswerCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="CreateEventHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CreateVendorQuestionAnswerHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<APIResponse> Handle(CreateVendorQuestionAnswerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<Vendorquestionanswers> vendorquestionanswers = new List<Vendorquestionanswers>();

                foreach (var item in request.VendorQuestionAnswer.VendorQuestionAnswers)
                {
                    var vendorquestionanswerrequest = mapper.Map<Vendorquestionanswers>(item);
                    vendorquestionanswers.Add(vendorquestionanswerrequest);
                }

                repository.VendorQuestionAnswer.CreateVendorQuestionAnswer(vendorquestionanswers);

                await repository.SaveAsync();

                return new APIResponse(vendorquestionanswers, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateVendorQuestionAnswerHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
