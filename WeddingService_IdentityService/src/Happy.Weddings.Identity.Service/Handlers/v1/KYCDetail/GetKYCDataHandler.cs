#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  25-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | GetKYCDataHandler class.
//----------------------------------------------------------------------------------------------

#endregion File Header

#region Namespaces

using System;
using MediatR;
using Serilog;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Happy.Weddings.Identity.Core.DTO.Responses;
using Happy.Weddings.Identity.Core.Repository;
using Happy.Weddings.Identity.Service.Queries.v1.Profile;
using Happy.Weddings.Identity.Service.Queries.v1.KYCDetail;
using AutoMapper;
using Happy.Weddings.Identity.Core.DTO.Responses.KYCDetail;
using System.Collections.Generic;
using Happy.Weddings.Identity.Core.Constants;

#endregion

namespace Happy.Weddings.Identity.Service.Handlers.v1.KYCDetail
{
    /// <summary>
    /// Handler for getting a profile.
    /// </summary>
    public class GetKYCDataHandler : IRequestHandler<GetKYCDataQuery, APIResponse>
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
        /// Gets or sets the mapper.
        /// </summary>
        /// <value>
        /// The mapper.
        /// </value>
        public IMapper mapper { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetKYCDataHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetKYCDataHandler(
            IMapper mapper,
            IRepositoryWrapper repository,
            ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the specified get kyc datas query.
        /// </summary>
        /// <param name="getKYCDatasQuery">The get kyc datas query.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<APIResponse> Handle(GetKYCDataQuery getKYCDatasQuery, CancellationToken cancellationToken)
        {
            try
            {
                var kYCDetails = await repository.KYCDataRepository.GetKYCDetailsByProfileId(getKYCDatasQuery.Id);
                if (kYCDetails == null)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }
                return new APIResponse(kYCDetails, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetKYCDataHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
