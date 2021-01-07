using System;
using System.Collections;
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
    /// <summary>
    /// Handler for updating a vendorquestionanswer
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Vendor.Service.Commands.v1.ServiceQuestion.UpdateServiceQuestionCommand, Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class UpdateVendorQuestionAnswerHandler : IRequestHandler<UpdateVendorQuestionAnswerCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="UpdateVendorQuestionAnswerHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UpdateVendorQuestionAnswerHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<APIResponse> Handle(UpdateVendorQuestionAnswerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<Vendorquestionanswers> vendorquestionanswers = new List<Vendorquestionanswers>();

                ArrayList qIdList = new ArrayList();

                foreach (var item in request.UpdateVendorQusetionAnswerDetailsRequest.UpdateVendorQuestionAnswers)
                {
                    var vendorquestionanswerrequest = mapper.Map<Vendorquestionanswers>(item);

                    if (vendorquestionanswerrequest.VendorLeadId == null) vendorquestionanswerrequest.VendorLeadId = request.VendorleadId;
                    vendorquestionanswerrequest.CreatedAt = DateTime.UtcNow;
                    vendorquestionanswerrequest.CreatedBy = (int)vendorquestionanswerrequest.UpdatedBy;
                    vendorquestionanswerrequest.UpdatedAt = null;
                    vendorquestionanswerrequest.UpdatedBy = null;

                    vendorquestionanswers.Add(vendorquestionanswerrequest);

                    if (!qIdList.Contains(vendorquestionanswerrequest.QuestionId)) qIdList.Add(vendorquestionanswerrequest.QuestionId);

                }

                for (int i = 0; i <= (qIdList.Count - 1); i++)
                {
                    var vendorquestionanswerList = await repository.VendorQuestionAnswer.GetVendorQuestionAnswers(request.VendorleadId, (int)qIdList[i]);

                    repository.VendorQuestionAnswer.UpdateVendorQuestionAnswer(vendorquestionanswerList);

                    await repository.SaveAsync();
                }

                repository.VendorQuestionAnswer.CreateVendorQuestionAnswer(vendorquestionanswers);
                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateVendorQuestionAnswerHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
