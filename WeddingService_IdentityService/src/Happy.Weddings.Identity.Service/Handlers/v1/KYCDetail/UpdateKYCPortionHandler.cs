#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  26-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateKYCPortionHandler class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using MediatR;
using Serilog;
using AutoMapper;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.Repository;
using Happy.Weddings.Identity.Service.Commands.v1.KYCDetail;
using Happy.Weddings.Identity.Core.Constants;
using System.Linq;

#endregion

namespace Happy.Weddings.Identity.Service.Handlers.v1.KYCDetail
{
    /// <summary>
    /// Handler for updating user profile portion.
    /// </summary>
    public class UpdateKYCPortionHandler : IRequestHandler<UpdateKYCPortionCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="UpdateKYCPortionHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UpdateKYCPortionHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }
        public async Task<APIResponse> Handle(UpdateKYCPortionCommand updateCommand, CancellationToken cancellationToken)
        {
            try
            {
                var response = new APIResponse(HttpStatusCode.NotFound);
                var kycDetails = await repository.KYCDataRepository.GetKYCDataByProfileId(updateCommand.Id);

                if (kycDetails != null)
                {
                    foreach (var requestData in updateCommand.Request.KYCPortionData)
                    {
                        var kycData = kycDetails.FirstOrDefault(x => x.Kycid == requestData.KycId);
                        {
                            if (kycData != null)
                            {
                                kycData.Kycstatus = requestData.KYCStatus;
                                kycData.UpdatedBy = requestData.UpdatedBy;
                                kycData.UpdatedAt = DateTime.UtcNow;
                            }
                        }
                    }
                    repository.KYCDataRepository.UpdateKYCDetail(kycDetails);
                    await repository.SaveAsync();
                    response = new APIResponse(HttpStatusCode.NoContent);
                }
                return response;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateKYCPortionHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
