﻿#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | UpdateSubscriptionPlanHandler --class
//----------------------------------------------------------------------------------------------

#endregion File Header
using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Commands.v1.SubscriptionPlans;
using Happy.Weddings.Vendor.Service.Commands.v1.SuggestionList;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.SuggestionLists
{
    /// <summary>
    /// Handler for updating a SuggestionLists
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Vendor.Service.v1.Commands.UpdateSubscriptionPlanCommand, Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class UpdateSuggestionlistHandler : IRequestHandler<UpdateSuggestionListCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="UpdateSubscriptionPlanHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UpdateSuggestionlistHandler(
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
        public async Task<APIResponse> Handle(UpdateSuggestionListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var subscription = await repository.SuggestionLists.GetSuggestionListById(request.SuggestionListId);
                if (subscription == null)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }

                var storyRequest = mapper.Map(request.Request, subscription);
                repository.SuggestionLists.UpdateSuggestionList(storyRequest);

                await repository.SaveAsync();

                return new APIResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'UpdateSubscriptionPlansHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
