#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  03-Sep-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | UpdateServiceAnswerHandler --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Commands.v1.ServiceAnswer;
using Happy.Weddings.Vendor.Service.Commands.v1.ServiceQuestion;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.ServiceAnswer
{
    /// <summary>
    /// Handler for updating a service answer
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Vendor.Service.Commands.v1.ServiceQuestion.UpdateServiceQuestionCommand, Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class UpdateServiceAnswerHandler : IRequestHandler<UpdateAnswerCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="UpdateServiceAnswerHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UpdateServiceAnswerHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<APIResponse> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<Serviceanswer> serviceanswers = new List<Serviceanswer>();

                var serviceanswer = await repository.ServiceAnswer.GetServiceAnswerById(request.QuestionId);

                if (serviceanswer == null) return new APIResponse(HttpStatusCode.NotFound);

                foreach (var item in request.ServiceAnswerDetails.UpdateServiceAnswers)
                {
                    var serviceanswerrequest = mapper.Map(item, serviceanswer);
                    serviceanswers.Add(serviceanswerrequest);

                    break;
                }

                repository.ServiceAnswer.UpdateServiceAnswerRange(serviceanswers);

                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateServiceQuestionHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
