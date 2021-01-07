#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  05-Aug-2020 |    REJI SALOOJA B S  | Created and implemented. 
//              |                      | CreateMultiCodeHandler --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Commands.v1.MultiCode;
using Happy.Weddings.Vendor.Core.Entity;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.MultiCode
{
    /// <summary>
    /// Handler for creating multicodes
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Vendor.Service.v1.Queries.CreateMultiCodeCommand, Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />

    public class CreateMultiCodeHandler : IRequestHandler<CreateMultiCodeCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="CreateMultiCodeHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CreateMultiCodeHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMultiCodeHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        /// 
        public async Task<APIResponse> Handle(CreateMultiCodeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var multicode = await repository.MultiCodes.GetMultiCodeById(request.Request.Code);

                if (multicode == null)
                {
                    var multicodeRequest = mapper.Map<Multicode>(request.Request);
                    multicodeRequest.SystemCode = multicodeRequest.Code;

                    repository.MultiCodes.CreateMultiCode(multicodeRequest);

                    await repository.SaveAsync();

                    return new APIResponse(multicodeRequest, HttpStatusCode.Created);
                }
                else
                {
                    return new APIResponse(HttpStatusCode.NoContent);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateStoryHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
