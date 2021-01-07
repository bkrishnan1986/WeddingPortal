#region File Header

// Copyright (C) 2020 NIRA Systems (P) Ltd.
//
// Release history:
//----------------------------------------------------------------------------------------------
// Date | Author | Description
//----------------------------------------------------------------------------------------------
// 06-Aug-2020 | Nithin M  | Created and implemented.
// | | UpdateAssetHandler class.
//----------------------------------------------------------------------------------------------

#endregion File Header

using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Commands.v1.Asset;
using MediatR;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.Asset
{
    /// <summary>
    /// Handler for updating a Asset
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{Happy.Weddings.Blog.Service.v1.Commands.UpdateassetCommands, Happy.Weddings.Blog.Core.DTO.Responses.APIResponse}" />
    public class UpdateAssetHandler : IRequestHandler<UpdateAssetCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="UpdateAssetHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public UpdateAssetHandler(
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
            public async Task<APIResponse> Handle(UpdateAssetCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var assets = await repository.AssetRepository.GetAssetsById(request.AssetId);
                    if (assets == null)
                    {
                        return new APIResponse(HttpStatusCode.NotFound);
                    }

                    var assetRequest = mapper.Map(request.Request, assets);
                    repository.AssetRepository.UpdateAssets(assetRequest);

                    await repository.SaveAsync();

                    return new APIResponse(HttpStatusCode.NoContent);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Exception in method 'UpdateassetHandler()'");
                    var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
                }
            }
        }
    }
