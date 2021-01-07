#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
//     Date     |      Author       |               Description
//----------------------------------------------------------------------------------------------
//  06-Aug-2020 |    ARAVIND PERUMAL S    | Created and implemented. 
//              |                         | CreateCommentReplyHandler --class
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Commands.v1.CommentReply;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.CommentReply
{
    /// <summary>
    /// Handler for creating a CommentReply
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Vendor.Service.v1.Commands.CreateBenefitCommand, Happy.Weddings.Vendor.Core.DTO.Responses.APIResponse}" />
    public class CreateCommentReplyHandler : IRequestHandler<CreateCommentReplyCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="CreateCommentReplyHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CreateCommentReplyHandler(
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
        public async Task<APIResponse> Handle(CreateCommentReplyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var commentreplyRequest = mapper.Map<Commentreply>(request.Request);
                if (commentreplyRequest.ParentCommentId == 0)
                {
                    commentreplyRequest.ParentCommentId = null;
                }
                if (commentreplyRequest.ParentReplyId == 0)
                {
                    commentreplyRequest.ParentReplyId = null;
                }
                repository.CommentReply.CreateCommentReply(commentreplyRequest);

                await repository.SaveAsync();

                return new APIResponse(commentreplyRequest, HttpStatusCode.Created);
                // return null;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateBenefitHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
