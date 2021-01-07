#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | AddServiceHandler class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Commands.v1.Service;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.ServiceHandler
{
    /// <summary>
    /// AddServiceHandler
    /// </summary>
    public class AddServiceHandler : IRequestHandler<CreateServiceCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="AddServiceHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public AddServiceHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<APIResponse> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<Services> services = new List<Services>();

                foreach (var item in request.Request.Services)
                {
                    var serviceRequest = mapper.Map<Services>(item);
                    services.Add(serviceRequest);

                    var serviceid = new APIResponse(serviceRequest.Id, HttpStatusCode.Created);

                    if (serviceid == null)
                    {
                        return new APIResponse(HttpStatusCode.NotFound);
                    }

                    var serviceofferlist = item.ServiceOfferList;
                    if (serviceofferlist != null)
                    {
                        foreach (var items in serviceofferlist)
                        {
                            var servicOfferRequest = mapper.Map<Serviceoffered>(items);
                           // servicOfferRequest.ServiceId = serviceRequest.Id;
                            servicOfferRequest.Active = serviceRequest.Active;
                            servicOfferRequest.CreatedBy = serviceRequest.CreatedBy;
                            repository.ServiceOffer.CreateServicesOffer(servicOfferRequest);
                        }
                    }
                }

                repository.ServiceRepository.CreateServices(services);
                await repository.SaveAsync();

                return new APIResponse(services, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateServiceHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
