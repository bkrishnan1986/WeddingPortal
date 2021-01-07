#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  24-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | CreateKYCDataHandler class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using MediatR;
using Serilog;
using System;
using System.Net;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Happy.Weddings.Identity.Core.Repository;
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.DTO.Responses.Profile;
using Happy.Weddings.Identity.Service.Commands.v1.KYCDetail;
using Happy.Weddings.Identity.Core.Entity;
using System.Collections.Generic;
using AutoMapper.Internal;

#endregion

namespace Happy.Weddings.Identity.Service.Handlers.v1.KYCDetail
{
    /// <summary>
    /// Handler for creating KYC.
    /// </summary>
    public class CreateKYCDataHandler : IRequestHandler<CreateKYCDataCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="CreateKYCDataHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CreateKYCDataHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        /// <summary>
        /// Handles the specified create command.
        /// </summary>
        /// <param name="createCommand">The create command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<APIResponse> Handle(CreateKYCDataCommand createCommand, CancellationToken cancellationToken)
        {
            try
            {
                List<Kycdata> kycdata = new List<Kycdata>();
                foreach (var item in createCommand.Request.KYCData)
                {
                    var kycDataRequest = mapper.Map<Kycdata>(item);
                    kycDataRequest.VendorId = createCommand.ProfileId;
                    kycDataRequest.Kycdetails.ForAll(x => x.CreatedBy = kycDataRequest.CreatedBy);
                    kycDataRequest.Kycdetails.ForAll(x => x.CreatedAt = DateTime.UtcNow);
                    kycDataRequest.Gstdetails.ForAll(x => x.CreatedBy = kycDataRequest.CreatedBy);
                    kycDataRequest.Gstdetails.ForAll(x => x.CreatedAt = DateTime.UtcNow);
                    kycdata.Add(kycDataRequest);
                }
                repository.KYCDataRepository.CreateKYCData(kycdata);
                await repository.SaveAsync();

                return new APIResponse(createCommand.Request, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateKYCDataHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
