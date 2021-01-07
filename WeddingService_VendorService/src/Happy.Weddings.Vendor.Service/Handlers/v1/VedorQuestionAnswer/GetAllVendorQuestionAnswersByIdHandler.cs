using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.DTO.Responses.VendorQuestionAnswer;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Queries.v1.VendorQuestionAnswer;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.DTO.Responses.ServiceQuestion;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.VedorQuestionAnswer
{
    public class GetAllVendorQuestionAnswersByIdHandler : IRequestHandler<GetAllVendorQuestionAnswersByIdQuery, APIResponse>
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
        /// The mapper
        /// </summary>
        private readonly IMapper mapper;   

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllServiceQuestionsByServiceTypeHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetAllVendorQuestionAnswersByIdHandler(
           IRepositoryWrapper repository,
            IMapper mapper,
           ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<APIResponse> Handle(GetAllVendorQuestionAnswersByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var vendorquestionserviceanswers = await repository.VendorQuestionAnswer.GetAllVendorQuestionAnswersById(request.VendorLeadId, request.IsForVendor);
                if (vendorquestionserviceanswers == null) return new APIResponse(HttpStatusCode.NotFound);

                foreach (var item in vendorquestionserviceanswers)
                {                      
                    var serviceanwerId = item.AnswerId;
                    var serviceAnswerList = await repository.ServiceAnswer.GetServiceAnswersById(serviceanwerId);
                    item.ServiceAnswer = serviceAnswerList;

                    var serviceQuestionId = item.QuestionId;
                    var serviceQuestionList = await repository.ServiceQuestion.GetServiceQuestionByServiceQuestionId(serviceQuestionId);
                    item.ServiceQuestion = serviceQuestionList;
                }
                return new APIResponse(vendorquestionserviceanswers, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetAllVendorQuestionAnswersByIdHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
