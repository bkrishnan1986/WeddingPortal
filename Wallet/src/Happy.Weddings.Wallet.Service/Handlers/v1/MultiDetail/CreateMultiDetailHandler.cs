#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | CreateMultiDetailHandler --class
//----------------------------------------------------------------------------------------------

#endregion

using AutoMapper;
using Happy.Weddings.Wallet.Core.DTO.Responses;
using Happy.Weddings.Wallet.Core.Entity;
using Happy.Weddings.Wallet.Core.Repository;
using Happy.Weddings.Wallet.Service.Commands.v1.MultiDetail;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Wallet.Service.Handlers.v1.MultiDetail
{
    /// <summary>
    /// Handler for creating multidetail
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Wallet.Service.Commands.v1.MultiDetail.CreateMultiDetailsCommand, Happy.Weddings.Wallet.Core.DTO.Responses.APIResponse}" />
    public class CreateMultiDetailHandler : IRequestHandler<CreateMultiDetailsCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="CreateMultiDetailHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CreateMultiDetailHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultiDetailHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        /// 
        public async Task<APIResponse> Handle(CreateMultiDetailsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var multidetailRequest = mapper.Map<Multidetail>(request.Request);
                repository.MultiDetails.CreateMultiDetails(multidetailRequest);

                await repository.SaveAsync();

                return new APIResponse(multidetailRequest, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateMultiDetailHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
