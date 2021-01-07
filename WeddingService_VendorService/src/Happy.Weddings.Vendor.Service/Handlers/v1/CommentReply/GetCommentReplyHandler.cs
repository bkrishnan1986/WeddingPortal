#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | GetCommentReplyHandler --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using System;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Queries.v1.CommentReply;
using MediatR;
using Serilog;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses.CommentReply;
using Happy.Weddings.Vendor.Core.DTO.Requests.CommentReply;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.CommentReply
{
    /// <summary>
    /// Handler for getting a CommentReply
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Vendor.Service.v1.Queries.GetBenefitQuery, Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class GetCommentReplyHandler : IRequestHandler<GetCommentReplyQuery, APIResponse>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private IRepositoryWrapper repository;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger logger;

        private IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriptionPlanHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="logger">The logger.</param>
        public GetCommentReplyHandler(
            IRepositoryWrapper repository,
             IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>
        /// Response from the request
        /// </returns>
        public async Task<APIResponse> Handle(GetCommentReplyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var CommentReply = await repository.CommentReply.GetCommentReplyById(request.CommentReplyId);
                if (CommentReply == null)
                {
                    return new APIResponse(HttpStatusCode.NotFound);
                }
                var replyCount = await repository.ReplyCounts.GetReplyCount(request.ReplyCountParameter);

                var reviewData = mapper.Map<ReplyDataResponse>(CommentReply);

                reviewData.Count = replyCount.Count;

                return new APIResponse(reviewData, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'GetCommentReplyHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}

