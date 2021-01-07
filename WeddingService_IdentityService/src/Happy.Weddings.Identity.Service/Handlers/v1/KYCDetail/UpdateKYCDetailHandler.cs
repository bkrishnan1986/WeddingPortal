#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  24-Aug-2020 |    Sumith C       | Created and implemented. 
//              |                   | UpdateKYCDetailHandler class.
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
using Happy.Weddings.Identity.Service.Commands.v1.KYCDetail;
using Happy.Weddings.Identity.Core.Entity;
using System.Linq;
using Happy.Weddings.Identity.Core.DTO.Responses.KYCDetail;
using System.Collections.Generic;
using AutoMapper.Internal;
using System.Security.Cryptography.X509Certificates;
using Serilog.Events;

#endregion

namespace Happy.Weddings.Identity.Service.Handlers.v1.KYCDetail
{
    /// <summary>
    /// Handler for creating KYC.
    /// </summary>
    public class UpdateKYCDetailHandler : IRequestHandler<UpdateKYCDataCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="UpdateKYCDetailHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UpdateKYCDetailHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        /// <summary>
        /// Handles the specified update command.
        /// </summary>
        /// <param name="updateCommand">The update command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<APIResponse> Handle(UpdateKYCDataCommand updateCommand, CancellationToken cancellationToken)
        {
            try
            {
                var response = new APIResponse(HttpStatusCode.NotFound);
                var kycDetails = await repository.KYCDataRepository.GetKYCDataByProfileId(updateCommand.ProfileId);

                if (kycDetails != null)
                {
                    foreach (var requestData in updateCommand.Request.UpdateData)
                    {
                        var kycData = kycDetails.FirstOrDefault(x => x.Kycid == requestData.Kycid);
                        if (kycData != null)
                        {
                            kycData.FatherName = requestData.FatherName;
                            kycData.Dob = requestData.Dob;
                            kycData.DocumentId = requestData.DocumentId;
                            if (null != requestData.KYCDetails)
                            {
                                kycData.Kycdetails = requestData.KYCDetails.Select(x =>
                                new Kycdetails()
                                {
                                    KycdocPath = x.KycdocPath,
                                    CreatedBy = requestData.UpdatedBy ?? 0,
                                    CreatedAt = DateTime.UtcNow
                                }).ToList();
                            }
                            if (null != requestData.KYCDetails)
                            {
                                var GST = kycData.Gstdetails.FirstOrDefault();
                                if (null != GST)
                                {
                                    GST.Gstcity = requestData.GSTDetails.Gstcity;
                                    GST.Gststate = requestData.GSTDetails.Gststate;
                                    GST.Gstnumber = requestData.GSTDetails.Gstnumber;
                                    GST.Gstdocument = requestData.GSTDetails.Gstdocument;
                                    GST.UpdatedAt = DateTime.UtcNow;
                                    GST.UpdatedBy = requestData.UpdatedBy;
                                }
                                else
                                {
                                    Gstdetails gstDetail = new Gstdetails()
                                    {
                                        Gstcity = requestData.GSTDetails.Gstcity,
                                        Gststate = requestData.GSTDetails.Gststate,
                                        Gstnumber = requestData.GSTDetails.Gstnumber,
                                        Gstdocument = requestData.GSTDetails.Gstdocument,
                                        CreatedBy = requestData.UpdatedBy ?? 0,
                                        CreatedAt = DateTime.UtcNow,
                                    };
                                    kycData.Gstdetails.Add(gstDetail);
                                }
                            }
                        }
                    }
                }

                repository.KYCDataRepository.UpdateKYCDetail(kycDetails);
                await repository.SaveAsync();
                response = new APIResponse(HttpStatusCode.NoContent);


                return response;

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateKYCDetailHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
