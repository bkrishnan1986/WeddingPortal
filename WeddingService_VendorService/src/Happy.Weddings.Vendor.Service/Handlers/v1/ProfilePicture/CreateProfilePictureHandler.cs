using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Happy.Weddings.Vendor.Core.DTO.Responses;
using Happy.Weddings.Vendor.Core.Entity;
using Happy.Weddings.Vendor.Core.Repository;
using Happy.Weddings.Vendor.Service.Commands.v1.ProfilePicture;
using MediatR;
using Serilog;

namespace Happy.Weddings.Vendor.Service.Handlers.v1.ProfilePicture
{
    public class CreateProfilePictureHandler : IRequestHandler<CreateProfielPictureCommand, APIResponse>
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
        /// Initializes a new instance of the <see cref="CreateEventHandler" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public CreateProfilePictureHandler(
            IRepositoryWrapper repository,
            IMapper mapper,
            ILogger logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<APIResponse> Handle(CreateProfielPictureCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pictureRequest = mapper.Map<Profilepictures>(request.Request);
                repository.ProfilePicture.CreateProfilePicture(pictureRequest);

                await repository.SaveAsync();

                return new APIResponse(pictureRequest, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception in method 'CreateProfilePictureHandler()'");
                var exMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return new APIResponse(exMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}
